using Amazon;

namespace SqsExample.Models
{
    public class SqsExampleSettings
    {
        public RegionEndpoint Region { get; set; }
        public string QueueUrl { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
    }
}