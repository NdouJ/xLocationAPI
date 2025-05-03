using System.Text.Json.Serialization;

namespace xLocationAPI.Models
{
    public class FoursquarePlace
    {
       [JsonPropertyName("fsq_id")]
        public string FsqId { get; set; }
        [JsonPropertyName("closed_bucket")]
        public string ClosedBucket { get; set; }
        public int Distance { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
        [JsonPropertyName("geocodes")]
        public Geocodes Geocodes { get; set; }
    }
}
