namespace Chat.Core.Dto
{
    public class MessageCreate
    {
        public string? Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UserId { get; set; }
        public int? ChatId { get; set; }

        public Data.Entities.Message ToEntity()
        {
            return new Data.Entities.Message()
            {
                Content = this.Content,
                CreateDate = this.CreateDate.Value,
                UserId = this.UserId.Value,
                ChatId = this.ChatId.Value
            };
        }
    }
}
