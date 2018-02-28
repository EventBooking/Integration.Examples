using System;
using System.Collections.Generic;
using System.Configuration;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Newtonsoft.Json;

namespace SqsExample
{
    public class SqsExample
    {
        private readonly RegionEndpoint _region;
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly string _queueUrl;

        public SqsExample()
        {
            _region = RegionEndpoint.GetBySystemName( ConfigurationManager.AppSettings["Region"] );
            _queueUrl = ConfigurationManager.AppSettings["QueueUrl"];
            _accessKey = ConfigurationManager.AppSettings["AccessKey"];
            _secretKey = ConfigurationManager.AppSettings["SecretKey"];
        }

        public void SendMessage()
        {
            var model = new ExampleMessageModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Sample message"
            };

            var serializedModel = JsonConvert.SerializeObject( model );

            var modelType = new MessageAttributeValue
            {
                DataType = "String",
                StringValue = model.GetType().Name
            };

            var queue = new AmazonSQSClient( _accessKey, _secretKey, _region );
            queue.SendMessage( new SendMessageRequest
            {
                QueueUrl = _queueUrl,
                MessageBody = serializedModel,
                MessageAttributes = new Dictionary<string, MessageAttributeValue>
                {
                    { "ModelType", modelType },
                }
            } );
            Console.Write( "Sent message: {0}", serializedModel );
        }

        public void ReceiveMessage()
        {
            var receiveRequest = new ReceiveMessageRequest
            {
                QueueUrl = _queueUrl
            };
            var queue = new AmazonSQSClient( _accessKey, _secretKey, _region );

            var receiveResponse = queue.ReceiveMessage( receiveRequest );
            receiveResponse.Messages.ForEach( x =>
            {
                Console.Write( "Received message: {0}", x.Body );

                var obj = JsonConvert.DeserializeObject<ExampleMessageModel>( x.Body );
                if (obj == null)
                    return;

                var deleteMessageRequest = new DeleteMessageRequest
                {
                    QueueUrl = _queueUrl,
                    ReceiptHandle = x.ReceiptHandle
                };
                queue.DeleteMessage( deleteMessageRequest );
            } );
        }
    }
}