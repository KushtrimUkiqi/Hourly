namespace WebApp.Models
{
    public class TenantIndexModel
    {
        public string Name { get; set; }

        public string Address { get; set; } = string.Empty;

        public string WebSite { get; set; } = string.Empty;

        public string? Error { get; set; } = null;
    }
}
