namespace reWrite.Models
{
    public class ResponseService<T>
    {
        public T Data { get; set; }
        public string Message { get; set; } = null;
        public bool Success { get; set; } = false;
    }
}
