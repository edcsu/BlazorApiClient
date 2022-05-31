using BlazorApiClient.Config;
using BlazorApiClient.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApiClient.Pages
{
    public partial class FetchData
    {
        [Inject]
        private HttpClient? Http { get; set; }
        
        [Inject]
        private IConfiguration configuration { get; set; }

        private LaunchDto[]? launchDtos;

        protected override async Task OnInitializedAsync()
        {
            var spaceXSettings = configuration.GetSpaceXSettings();
            launchDtos = await Http!.GetFromJsonAsync<LaunchDto[]>($"/{spaceXSettings.RestSegment}/{spaceXSettings.LaunchPath}");
        }
    }
}
