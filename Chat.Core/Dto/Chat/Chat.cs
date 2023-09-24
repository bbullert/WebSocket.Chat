namespace Chat.Core.Dto
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Data.Entities.Chat ToEntity()
        {
            return new Data.Entities.Chat()
            {
                Id = this.Id,
                Name = this.Name
            };
        }

        public static Chat FromEntity(Data.Entities.Chat entity)
        {
            return new Chat()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
