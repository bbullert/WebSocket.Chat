namespace Chat.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserAvatar { get; set; }
        public int ChatId { get; set; }
    }
}
