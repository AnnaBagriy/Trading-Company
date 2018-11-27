using BLL.Interfaces;

namespace BLL.Services
{
    public class Response : IResponse
    {
        public string Message { get; set; }

        public Response(string message)
        {
            Message = message;
        }
    }
}
