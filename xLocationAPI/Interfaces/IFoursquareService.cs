using xLocationAPI.Models;

namespace xLocationAPI.Interfaces
{
    public interface IFoursquareService
    {
        public Task<List<FoursquarePlace>> GetNearbyPlacesAsync(double latitude, double longitude);
    }
}
