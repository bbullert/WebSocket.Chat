using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chat.Core.Dto
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Avatar { get; set; }

        public Data.Entities.User ToEntity()
        {
            return new Data.Entities.User()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Avatar = this.Avatar,
            };
        }

        public static User FromEntity(Data.Entities.User entity)
        {
            return new User()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Avatar = entity.Avatar,
            };
        }
    }
}
