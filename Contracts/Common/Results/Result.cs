namespace Contracts.Common.Results
{
    public class Result
    {
        public bool IsSucess { get; set; }

        public bool IsFailure => !IsSucess;

        public ResultCode ResultCode { get; set; }

        public string? ErrorMessage { get; set; }

        protected internal Result(bool isSuccess, ResultCode resultCode, string? errorMessage  = null)
        {
            if (isSuccess && errorMessage != null)
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && errorMessage == null)
            {
                throw new InvalidOperationException();
            }

            IsSucess = isSuccess;
            ResultCode = resultCode;
            ErrorMessage = errorMessage;
        }

        public static Result OK() => new(true, ResultCode.OK);

        public static Result NO_CONTENT() => new(true, ResultCode.NO_CONTENT);

        public static Result BAD_REQUEST() => new(false, ResultCode.BAD_REQUEST);

        public static Result UNAUTHORIZED() => new(false, ResultCode.UNAUTHORIZED);

        public static Result NOT_FOUND() => new(false, ResultCode.NOT_FOUND);

        public static Result CONFLICT() => new(false, ResultCode.CONFLICT);

        public static Result FAILED() => new(true, ResultCode.FAILED);

    }
}
