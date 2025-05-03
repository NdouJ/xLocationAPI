using System.Text.Json.Serialization;

namespace xLocationAPI.Models
{
    public class Geocodes
    {
        [JsonPropertyName("main")]
        public GeoCoordinates Main { get; set; }
    }
}
