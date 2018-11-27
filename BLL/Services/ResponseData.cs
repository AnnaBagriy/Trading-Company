using BLL.Interfaces;

namespace BLL.Services
{
    public class ResponseData<T> : IResponseData<T>
        where T : class, new()
    {
        public T Data { get; set; }
        public string Message { get; set; }

        public ResponseData(T data, string message)
        {
            Data = data;
            Message = message;
        }
    }
}
