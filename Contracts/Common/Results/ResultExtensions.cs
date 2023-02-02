namespace Contracts.Common.Results
{
    public static class ResultExtensions
    {
        public static bool CheckIfAnyFailure(this IEnumerable<Result> results)
        {
            return results.Any(x => x.IsFailure);
        }
    }
}
