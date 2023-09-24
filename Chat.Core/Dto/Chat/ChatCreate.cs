namespace Chat.Core.Dto
{
    public class ChatCreate
    {
        public string? Name { get; set; }

        public Data.Entities.Chat ToEntity()
        {
            return new Data.Entities.Chat()
            {
                Name = this.Name
            };
        }
    }
}
