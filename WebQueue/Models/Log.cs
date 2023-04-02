using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebQueue.Enums;

namespace WebQueue.Models
{
    [Table("logs")]
    public class Log
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [DataMember]
        [Column("action_context")]
        public LogContext Context { get; set; }
        [DataMember]
        [Column("last_message_id")]
        public Guid LastMessageId { get; set; }
        [DataMember]
        [Column("time")]
        public DateTime Time { get; set; }
    }
}
