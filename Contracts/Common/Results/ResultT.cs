namespace Contracts.Common.Results
{
    public class Result<TValue> : Result
    {
        public TValue? Value { get; private set; }

        protected internal Result(TValue? value, bool isSuccess, ResultCode resultCode, string errorMessage = null)
            : base(isSuccess, resultCode, errorMessage)
        {
            Value = value;
        }

        protected internal Result(bool isSuccess, ResultCode resultCode, string? errorMessage = null)
            : base(isSuccess, resultCode, errorMessage)
        { }

        public static Result<TValue> OK(TValue value) => new(value, true, ResultCode.OK);

        public static Result<TValue> CREATED(TValue value) => new(value, true, ResultCode.CREATED);

        public static Result<TValue> BAD_REQUEST(string errorMessage) => new(false, ResultCode.BAD_REQUEST, errorMessage);

        public static Result<TValue> UNAUTHORIZED(string errorMessage) => new(false, ResultCode.UNAUTHORIZED, errorMessage);

        public static Result<TValue> NOT_FOUND(string errorMessage) => new(false, ResultCode.NOT_FOUND, errorMessage);

        public static Result<TValue> CONFLICT(string errorMessage) => new(false, ResultCode.CONFLICT, errorMessage);

        public static Result<TValue> FAILED(string errorMessage) => new(false, ResultCode.FAILED, errorMessage);

        public static Result<TValue> FROM_ERROR(Result result) => new(false, result.ResultCode, result.ErrorMessage);
    }
}
