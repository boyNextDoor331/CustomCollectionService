using CustomCollectionService;
using CustomCollectionService.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebQueue.Data;
using WebQueue.Models;
using WebQueue.Enums;

namespace WebQueue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController
    {
        private QueueCollection<Message> _queue;
        private ApplicationDbContext _context;
        private SaveProcessTrigger _saveProcessTrigger;
        public MessageController(QueueCollection<Message> queue, ApplicationDbContext context, SaveProcessTrigger saveProcessTrigger)
        {
            _queue = queue;
            _context = context;
            _saveProcessTrigger = saveProcessTrigger;
        }

        [HttpGet]
        public Message Read()
        {
            if (_queue.Capacity > 0)
            {
                return _queue.Dequeue();
            }
            else throw new EmptyQueueException("The queue is empty");
        }

        [HttpPost]
        public void Write(string title, string body)
        {
            
            if(_queue.Capacity <= 100 && _saveProcessTrigger.NextIterationTime >= DateTime.Now)
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
                else throw new ArgumentNullException("Argument must not be null");
            }
            else
            {
                try
                {
                    _context.AddRange(_queue.Messages);
                    _context.SaveChanges();
                }
                catch
                {
                    throw new InvalidOperationException();
                }
                finally
                {
                    _context.Add(new Log
                    {
                        Id = Guid.NewGuid(),
                        Context = LogContext.QUEUE_FILLING,
                        LastMessageId = _queue.Messages[_queue.Capacity - 1].Id,
                        Time = DateTime.Now
                    });
                    _context.SaveChanges();
                    _queue.Clean();
                    _saveProcessTrigger.CalculateNextTime();
                }

            }
            
        }
    }
}
