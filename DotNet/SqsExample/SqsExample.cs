using System;
using Amazon.SQS;
using Amazon.SQS.Model;
using Newtonsoft.Json;
using SqsExample.Models;

namespace SqsExample
{
    public class SqsExample
    {
        private readonly SqsExampleSettings _settings;

        public SqsExample(SqsExampleSettings settings)
        {
            _settings = settings;
        }
        
        public void ReceiveMessage()
        {
            var receiveRequest = new ReceiveMessageRequest
            {
                QueueUrl = _settings.QueueUrl
            };
            var queue = new AmazonSQSClient( _settings.AccessKey, _settings.SecretKey, _settings.Region );

            var receiveResponse = queue.ReceiveMessage( receiveRequest );
            receiveResponse.Messages.ForEach( x =>
            {
                Console.Write( "Received message: {0}", x.Body );

                var message= JsonConvert.DeserializeObject<PushMessage>( x.Body );
                if ( message== null)
                    return;

                ProcessMessage(message);

                var deleteMessageRequest = new DeleteMessageRequest
                {
                    QueueUrl = _settings.QueueUrl,
                    ReceiptHandle = x.ReceiptHandle
                };
                queue.DeleteMessage( deleteMessageRequest );
            } );
        }

        private void ProcessMessage(PushMessage message)
        {
            // TODO: Your code to process the message
            throw new NotImplementedException();
        }
    }
}