namespace Chat.Core.Dto
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateDateString => CreateDate.ToString();
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserAvatar { get; set; }
        public int ChatId { get; set; }

        public Data.Entities.Message ToEntity()
        {
            return new Data.Entities.Message()
            {
                Id = this.Id,
                Content = this.Content,
                CreateDate = this.CreateDate,
                UserId = this.UserId,
                UserFullName = this.UserFullName,
                UserAvatar = this.UserAvatar,
                ChatId = this.ChatId
            };
        }

        public static Message FromEntity(Data.Entities.Message entity)
        {
            return new Message()
            {
                Id = entity.Id,
                Content = entity.Content,
                CreateDate = entity.CreateDate,
                UserId = entity.UserId,
                UserFullName = entity.UserFullName,
                UserAvatar = entity.UserAvatar,
                ChatId = entity.ChatId
            };
        }
    }
}
