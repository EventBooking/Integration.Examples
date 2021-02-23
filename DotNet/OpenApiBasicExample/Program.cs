using OpenApiBasicExample.Models;

namespace OpenApiBasicExample
{
    public static class Program
    {
        public static void Main()
        {
            var settings = new OpenApiExampleSettings
            {
                ClientID = "EVENTBOOKING_STAFF_WILL_PROVIDE_CREDENTIALS",
                ClientSecret = "EVENTBOOKING_STAFF_WILL_PROVIDE_CREDENTIALS",
            };
            
            var example = new BasicExample(settings);
            example.Run().Wait();
        }
    }
}