using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiExample
{
    public class Program
    {
        private static void Main()
        {
            Run().Wait();
        }

        private static async Task Run()
        {
            var baseUrl = "https://BASE-URL/";
            var endpoint = "ENDPOINT";
            var apiKey = "API-KEY";
            var request = @"{ ""token"": ""TOKEN-VALUE"" }";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri( baseUrl );
                client.DefaultRequestHeaders.TryAddWithoutValidation( "Authorization", $"Key={apiKey}" );
                var body = new StringContent( request );
                var response = await client.PostAsync( endpoint, body );
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine( content );
                }
                else
                {
                    Console.WriteLine( "Got status code {0}", response.StatusCode );
                }
            }
        }
    }
}