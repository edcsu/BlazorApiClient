using System.Text.Json.Serialization;

namespace BlazorApiClient.Dtos
{
    public class LaunchDto
    {
        [JsonPropertyName("details")]
        public string? Details { get; set; }

#nullable disable
        [JsonPropertyName("id")]
        public string Id { get; set; }
#nullable enable

        [JsonPropertyName("is_tentative")]
        public bool? IsTentative { get; set; }

        [JsonPropertyName("launch_date_local")]
        public DateTimeOffset LaunchDateLocal { get; set; }

        [JsonPropertyName("launch_date_unix")]
        public long LaunchDateUnix { get; set; }

        [JsonPropertyName("launch_date_utc")]
        public DateTimeOffset LaunchDateUtc { get; set; }

        [JsonPropertyName("launch_site")]
        public LaunchSite? LaunchSite { get; set; }

        [JsonPropertyName("launch_success")]
        public bool? LaunchSuccess { get; set; }

#nullable disable
        [JsonPropertyName("launch_year")]
        public string LaunchYear { get; set; }
#nullable enable

        [JsonPropertyName("mission_id")]
        public List<string>? MissionId { get; set; }

        [JsonPropertyName("mission_name")]
        public string? MissionName { get; set; }

        [JsonPropertyName("upcoming")]
        public bool Upcoming { get; set; }
    }
}
