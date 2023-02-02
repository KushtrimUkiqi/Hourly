namespace Contracts.Common.Responses
{
    public class PageListResponse<T> : IGenericResponse
    {
        // <summary>
        // Tells the number of the page
        // </summary>
        public int PageNumber { get; set; }

        // <summary>
        // Tells the number items that are returned
        // </summary>
        public int Count { get; set; }

        // <summary>
        // Tells the number of all items
        // </summary>
        public int TotalCount { get; set; }

        // <summary>
        // List of items
        // </summary>
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}
