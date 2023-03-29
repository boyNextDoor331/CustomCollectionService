namespace CustomCollectionService.Exceptions
{
    public class EmptyQueueException : Exception
    {
        public EmptyQueueException(string message) : base(message) { }
    }
}
