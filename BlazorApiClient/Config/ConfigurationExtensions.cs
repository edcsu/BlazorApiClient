namespace BlazorApiClient.Config
{
    public static class ConfigurationExtensions
    {
        public static SpaceXSettings GetSpaceXSettings(this IConfiguration configuration)
        {
            return configuration.GetSection(SpaceXSettings.SettingsName).Get<SpaceXSettings>();
        }
    }
}
