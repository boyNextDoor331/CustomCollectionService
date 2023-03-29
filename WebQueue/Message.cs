namespace WebQueue
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime ReceiptTime { get; set; }
    }
}
