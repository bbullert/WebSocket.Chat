namespace Chat.Core.Dto
{
    public class UserCreate
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Avatar { get; set; }

        public Data.Entities.User ToEntity()
        {
            return new Data.Entities.User()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Avatar = this.Avatar,
            };
        }
    }
}
