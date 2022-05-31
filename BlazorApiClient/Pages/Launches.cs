using BlazorApiClient.Dtos;
using BlazorApiClient.Services.Data;
using Microsoft.AspNetCore.Components;

namespace BlazorApiClient.Pages
{
    public partial class Launches
    {
        private LaunchDto[]? launchDtos;

        [Inject]
        ISpaceXDataService? spaceXDataService { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            launchDtos = await spaceXDataService!.GetAllLaunches();
        }
    }
}
