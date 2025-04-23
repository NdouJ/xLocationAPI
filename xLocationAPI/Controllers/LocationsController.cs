using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using xLocationAPI.Interfaces;
using xLocationAPI.Models;

namespace xLocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IFoursquareService _foursquareService;

        public LocationsController(IFoursquareService foursquareService)
        {
            _foursquareService = foursquareService;
        }
        [HttpPost("nearby")]
        public async Task<IActionResult> GetNearbyPlaces([FromBody] LocationRequest request)
        {
            if (request == null || request.Latitude == 0 || request.Longitude == 0)
            {
                return BadRequest("Invalid location data.");
            }

            try
            {
                var places = await _foursquareService.GetNearbyPlacesAsync(request.Latitude, request.Longitude);
                return Ok(places);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
