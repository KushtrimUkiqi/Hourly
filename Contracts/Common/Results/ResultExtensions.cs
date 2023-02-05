namespace Contracts.Common.Results
{
    public static class ResultExtensions
    {
        public static bool CheckIfAnyFailure(this IEnumerable<Result> results)
        {
            return results.Any(x => x.IsFailure);
        }

        public static Result ReturnResult(this IEnumerable<Result> results)
        {
            Result? resultFailture =  results.FirstOrDefault(x => x.IsFailure);

            if(resultFailture != null)
            {
                return resultFailture;
            }

            return Result.OK();
        }
    }
}
