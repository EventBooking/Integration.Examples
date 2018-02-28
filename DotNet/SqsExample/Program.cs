namespace SqsExample
{
    public class Program
    {
        private static void Main()
        {
            var example = new SqsExample();
            example.SendMessage();
            example.ReceiveMessage();
        }
    }
}