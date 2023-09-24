namespace Chat.Api.Models
{
    public class ApiResponse<T>
    {
        public T Result { get; set; }
        public int Status { get; set; }
        public string Details { get; set; }
    }
}
