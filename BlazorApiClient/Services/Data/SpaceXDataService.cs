using BlazorApiClient.Config;
using BlazorApiClient.Dtos;
using System.Net.Http.Json;

namespace BlazorApiClient.Services.Data
{
    public class SpaceXDataService : ISpaceXDataService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public SpaceXDataService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<LaunchDto[]?> GetAllLaunches()
        {
            var spaceXSettings =_configuration.GetSpaceXSettings();
            var httpClient =_httpClientFactory.CreateClient("SpaceX");
            var launchDtos = await httpClient.GetFromJsonAsync<LaunchDto[]>(
                $"/{spaceXSettings.RestSegment}/{spaceXSettings.LaunchPath}");
            return launchDtos;
        }
    }
}
