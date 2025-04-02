namespace TCE.Application.DTOs
{
    public class MessageDTO<T>
    {
        public string Description { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
    }
}
