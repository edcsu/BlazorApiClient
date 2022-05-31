using BlazorApiClient.Config;
using BlazorApiClient.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApiClient.Pages
{
    public partial class FetchData
    {
        [Inject]
        private IHttpClientFactory? httpClientFactory { get; set; }
        
        [Inject]
        private IConfiguration? configuration { get; set; }

        private LaunchDto[]? launchDtos;

        protected override async Task OnInitializedAsync()
        {
            var spaceXSettings = configuration!.GetSpaceXSettings();
            var httpClient = httpClientFactory!.CreateClient("SpaceX");
            launchDtos = await httpClient.GetFromJsonAsync<LaunchDto[]>(
                $"/{spaceXSettings.RestSegment}/{spaceXSettings.LaunchPath}");
        }
    }
}
