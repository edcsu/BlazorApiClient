using BlazorApiClient.Config;
using BlazorApiClient.Dtos;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace BlazorApiClient.Services.Data
{
    public class GraphqlSpaceXDataService : ISpaceXDataService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public GraphqlSpaceXDataService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<LaunchDto[]?> GetAllLaunches()
        {
            var queryObject = new
            {
                query = @"query{
	                            launches{
		                            id
		                            details
		                            is_tentative
		                            launch_date_local
		                            launch_date_unix
		                            launch_date_utc
		                            launch_year
		                            launch_success
		                            launch_site{
			                            site_id
			                            site_name
			                            site_name_long
		                            }
		                            mission_id
		                            mission_name
		                            upcoming
	                            }
                            }",
                variables = new {}
            };

            var launchQuery = new StringContent(
                JsonSerializer.Serialize(queryObject),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            
            var spaceXSettings = _configuration.GetSpaceXSettings();
            var httpClient = _httpClientFactory.CreateClient("SpaceX");
            var response = await httpClient.PostAsync($"/{spaceXSettings.GraphqlSegment}/{spaceXSettings.LaunchPath}", launchQuery);
            if (response.IsSuccessStatusCode)
            {
               var gqlData = await JsonSerializer.DeserializeAsync<GqlData>(await response.Content.ReadAsStreamAsync());
                return gqlData!.Data.Launches;
            }
            
            return null;
        }
    }
}
