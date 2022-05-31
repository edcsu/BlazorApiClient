using BlazorApiClient.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApiClient.Pages
{
    public partial class FetchData
    {
        [Inject]
        private HttpClient? Http { get; set; }

        private LaunchDto[]? launchDtos;

        protected override async Task OnInitializedAsync()
        {
            launchDtos = await Http!.GetFromJsonAsync<LaunchDto[]>("https://api.spacex.land/rest/launches");
        }
    }
}
