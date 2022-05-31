using System.Text.Json.Serialization;

namespace BlazorApiClient.Dtos
{
    public class LaunchSite
    {
        [JsonPropertyName("site_id")]
        public string? SiteId { get; set; }

        [JsonPropertyName("site_name_long")]
        public string? SiteNameLong { get; set; }

        [JsonPropertyName("site_name")]
        public string? SiteName { get; set; }
    }
}
