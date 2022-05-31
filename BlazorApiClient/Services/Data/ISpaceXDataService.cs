using BlazorApiClient.Dtos;

namespace BlazorApiClient.Services.Data
{
    public interface ISpaceXDataService
    {
        Task<LaunchDto[]?> GetAllLaunches();
    }
}
