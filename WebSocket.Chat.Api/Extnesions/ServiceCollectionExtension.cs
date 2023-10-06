using Chat.Core.Dto;
using Chat.Core.Hubs;
using Chat.Core.Services;
using Chat.Core.Validators;
using Chat.Data.Repositories;
using FluentValidation;

namespace Chat.Api.Extnesions
{
    internal static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IChatUserService, ChatUserService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IChatMessageService, ChatMessageService>();

            services.AddTransient<ChatHub>();
        }

        public static void RegisterRepositries(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IChatUserRepository, ChatUserRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserCreate>, UserCreateValidator>();
            services.AddScoped<IValidator<ChatCreate>, ChatCreateValidator>();
            services.AddScoped<IValidator<ChatUserCreate>, ChatUserCreateValidator>();
            services.AddScoped<IValidator<MessageCreate>, MessageCreateValidator>();
        }
    }
}
