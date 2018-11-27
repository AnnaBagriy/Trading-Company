namespace BLL.Interfaces
{
    public interface IResponseData<T>
        where T : class, new()
    {
        T Data { get; set; }
        string Message { get; set; }
    }
}
