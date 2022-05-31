namespace BlazorApiClient.Config
{
    public class SpaceXSettings
    {
        public const string SettingsName = "SpaceXSettings";

        public string? BaseUrl { get; set; }

        public string? RestSegment { get; set; }

        public string? GraphqlSegment { get; set; }

        public string? LaunchPath { get; set; }

        public string? RocketPath { get; set; }
    }
}
