namespace Chat.Core.Dto
{
    public class ChatUserCreate
    {
        public int? ChatId { get; set; }
        public int? UserId { get; set; }

        public Data.Entities.ChatUser ToEntity()
        {
            return new Data.Entities.ChatUser()
            {
                ChatId = this.ChatId.Value,
                UserId = this.UserId.Value
            };
        }
    }
}
