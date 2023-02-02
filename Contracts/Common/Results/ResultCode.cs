namespace Contracts.Common.Results
{
    public class ResultCode
    {
        /// <summary>
        /// Code is returned when request is handled successfully
        /// </summary>
        public static readonly ResultCode OK = new("200");

        /// <summary>
        /// Code is returned when the resource has been created successfully
        /// </summary>
        public static readonly ResultCode CREATED = new("201");


        /// <summary>
        /// Code is returned when the request is processed successfully but nothing is returned as response
        /// </summary>
        public static readonly ResultCode NO_CONTENT = new("204");


        /// <summary>
        /// Code is returned when the request is not valid
        /// </summary>
        public static readonly ResultCode BAD_REQUEST = new("400");


        /// <summary>
        /// Code is returned when unauthorized requests arrive
        /// </summary>
        public static readonly ResultCode UNAUTHORIZED = new("401");


        /// <summary>
        /// Code is returned when the resource is not found
        /// </summary>
        public static readonly ResultCode NOT_FOUND = new("404");


        /// <summary>
        /// Code is returned when the request conflicts with rules of domain
        /// </summary>
        public static readonly ResultCode CONFLICT = new("409");

        /// <summary>
        /// Code is returned when the request can not be processed
        /// </summary>
        public static readonly ResultCode FAILED = new("500");

        public string Code { get; private set; }

        private ResultCode(string code)
        {
            Code = code;
        }
    }
}
