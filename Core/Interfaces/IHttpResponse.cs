namespace Core.Interfaces
{
    public interface IHttpResponse<T>
    {
        T Data { get; }

        bool Success { get; }

        IError Error { get; }
    }
}
