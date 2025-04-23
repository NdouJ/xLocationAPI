
using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;
using xLocationAPI.Interfaces;
using xLocationAPI.Models;

namespace xLocationAPI.Services
{
    public class FoursquareService :IFoursquareService
    {
        private string apiKey; 
        private HttpClient httpClient;
        public FoursquareService(string apiKey, HttpClient httpClient)
        {
            this.apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey), "API key is required");
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient), "HttpClient is required");
        }

        public async Task<List<FoursquarePlace>> GetNearbyPlacesAsync(double latitude, double longitude)
        {
            var requestUri = $"{httpClient.BaseAddress}/search?ll={latitude.ToString(CultureInfo.InvariantCulture)},{longitude.ToString(CultureInfo.InvariantCulture)}&radius=500";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.TryAddWithoutValidation("Authorization", apiKey);
            var response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<FoursquareResponse>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result?.Results ?? new List<FoursquarePlace>();
        }
    }
}
