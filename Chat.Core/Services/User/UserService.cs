﻿using Chat.Core.Dto;
using Chat.Data.Repositories;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace Chat.Core.Services
{
    public partial class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository
            )
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetAsync(int id)
        {
            var result = await _userRepository.GetAsync(id);
            if (result == null) return null;
            var user = User.FromEntity(result);

            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var result = await _userRepository.GetAllAsync();
            var users = result.Select(x => User.FromEntity(x)).ToList();

            return users;
        }

        public async Task<int> CreateAsync(UserCreate user)
        {
            var id = await _userRepository.CreateAsync(user.ToEntity());
            return id;
        }

        public async Task<IEnumerable<int>> CreateFromJsonAsync(IFormFile file)
        {
            if (file == null)
            {
                throw new HttpRequestException(
                    "File is required",
                    null, System.Net.HttpStatusCode.BadRequest);
            }
            if (file.Length == 0)
            {
                throw new HttpRequestException(
                    "File is empty",
                    null, System.Net.HttpStatusCode.UnprocessableEntity);
            }
            if (file.ContentType != "application/json")
            {
                throw new HttpRequestException(
                    "Invalid file type - Json type required",
                    null, System.Net.HttpStatusCode.UnprocessableEntity);
            }

            var content = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    content.AppendLine(await reader.ReadLineAsync());
            }

            var options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            };
            var users = JsonSerializer.Deserialize<IEnumerable<UserCreate>>(content.ToString(), options);

            var ids = new List<int>();
            foreach (var user in users)
            {
                var id = await CreateAsync(user);
                ids.Add(id);
            }

            return ids;
        }
    }
}
