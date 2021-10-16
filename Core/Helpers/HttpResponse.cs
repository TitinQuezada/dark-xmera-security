using Core.Interfaces;

namespace Core.Helpers
{
    public sealed class HttpResponse<T> : IHttpResponse<T>
    {
        private HttpResponse(IError error, T data, bool success)
        {
            Data = data;
            Success = success;
            Error = error;
        }

        public T Data { get; }

        public bool Success { get; }

        public IError Error { get; }

        public static HttpResponse<T> GetSuccessResponse(T data) => new HttpResponse<T>(null, data, true);

        public static HttpResponse<T> GetSuccessResponse() => new HttpResponse<T>(null, default, true);

        public static HttpResponse<T> GetFailedResponse(string errorMessage, int errorCode = 500) => new HttpResponse<T>(new Error
        {
            ErrorMessage = errorMessage,
            ErrorCode = errorCode
        }, default, false);
    }
}
