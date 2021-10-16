namespace Core.Interfaces
{
    public interface IError
    {
        string ErrorMessage { get; }

        int ErrorCode { get; }
    }
}
