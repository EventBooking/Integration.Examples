namespace SqsExample.Models
{
    public class PushMessage
    {
        public string Operation { get; set; } // See PushOperations
        public string ObjectType { get; set; } // See PushObjectTypes
        public string ObjectId { get; set; }
    }
}