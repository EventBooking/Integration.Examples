using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenApiBasicExample.Models;

namespace OpenApiBasicExample
{
    public class BasicExample
    {
        private readonly OpenApiExampleSettings _settings;

        public BasicExample(OpenApiExampleSettings settings)
        {
            _settings = settings;
        }

        public async Task Run()
        {
            var client = new HttpClient();

            var token = await Authenticate(client);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            await GetEventTypes(client);
        }

        private static async Task GetEventTypes(HttpClient client)
        {
            var result = await client.GetAsync("https://api.indv-venueops.com/v1/event-setup/event-types");
            if (!result.IsSuccessStatusCode)
                throw new Exception("Failed to get event types");

            var resultJson = await result.Content.ReadAsStringAsync();
            dynamic eventTypes = JsonConvert.DeserializeObject(resultJson);

            foreach (var eventType in eventTypes)
            {
                Console.WriteLine($"{eventType.id} = {eventType.name}");
            }
        }

        private async Task<string> Authenticate(HttpClient client)
        {
            var body = new
            {
                clientId = _settings.ClientID,
                clientSecret = _settings.ClientSecret
            };
            var bodyJson = JsonConvert.SerializeObject(body, Formatting.Indented);
            var content = new StringContent(bodyJson, Encoding.UTF8);
            var result = client.PostAsync("https://auth-api.indv-venueops.com/token", content);
            if (!result.Result.IsSuccessStatusCode)
                throw new Exception("Failed to authenticate");
            
            var resultJson = await result.Result.Content.ReadAsStringAsync();
            var resultObject = JsonConvert.DeserializeObject<OpenApiAuth>(resultJson);
            return resultObject.accessToken;
        }
    }
}