using Core.Interfaces;

namespace Core.Helpers
{
    public sealed class Error : IError
    {
        public string ErrorMessage { get; set; }

        public int ErrorCode { get; set; }
    }
}
