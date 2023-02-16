namespace WebApp.Models
{
    public class GeneralModel<T>
    {
        public T? Value { get; set; }

        public string? Error { get; set; }
    }
}
