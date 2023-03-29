using CustomCollectionService;
using CustomCollectionService.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebQueue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController
    {
        private QueueCollection<Message> _queue;
        public MessageController(QueueCollection<Message> queue )
        {
            _queue = queue;
        }

        [HttpGet]
        public Message Get()
        {
            if (_queue.Capacity > 0)
            {
                return _queue.Dequeue();
            }
            else throw new EmptyQueueException("The queue is empty ");
        }

        [HttpPost]
        public void Put(string title, string body)
        {
            if (title != null && body != null)
            {
                _queue.Enqueue(new Message
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Body = body,
                    ReceiptTime = DateTime.Now,
                }
                );
            }
        }
    }
}
