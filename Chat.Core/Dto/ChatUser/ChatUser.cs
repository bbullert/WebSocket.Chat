namespace Chat.Core.Dto
{
    public class ChatUser
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }

        public Data.Entities.ChatUser ToEntity()
        {
            return new Data.Entities.ChatUser()
            {
                Id = this.Id,
                ChatId = this.ChatId,
                UserId = this.UserId
            };
        }

        public static ChatUser FromEntity(Data.Entities.ChatUser entity)
        {
            return new ChatUser()
            {
                Id = entity.Id,
                ChatId = entity.ChatId,
                UserId = entity.UserId
            };
        }
    }
}
