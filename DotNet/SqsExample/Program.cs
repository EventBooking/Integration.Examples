using Amazon;
using SqsExample.Models;

namespace SqsExample
{
    public static class Program
    {
        public static void Main()
        {
            var settings = new SqsExampleSettings
            {
                Region = RegionEndpoint.GetBySystemName("us-west-2"),
                QueueUrl = "http://sqs.us-west-2.amazonaws.com/URL_FROM_THE_AWS_ACCOUNT",
                AccessKey = "CREDENTIALS_FROM_THE_AWS_ACCOUNT",
                SecretKey = "CREDENTIALS_FROM_THE_AWS_ACCOUNT",
            };

            var example = new SqsExample(settings);
            example.ReceiveMessage();
        }
    }
}