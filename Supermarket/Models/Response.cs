namespace Supermarket.Models
{
    public class Response<T>
    {
        public Response(T data)
        {
            Data = data;
        }

        public Response()
        {
        }

        public T? Data { get; set; } 
        public string? Message { get; set; }

    }
}
