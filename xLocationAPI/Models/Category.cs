using System.Text.Json.Serialization;

namespace xLocationAPI.Models
{
    public class Category
    {
        [JsonPropertyName("short_name")]
        public string ShortName { get; set; }

        public int id { get; set; }
    }
}
