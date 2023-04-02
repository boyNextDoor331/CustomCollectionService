using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WebQueue.Models
{
    [Table("messages")]
    public class Message
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [DataMember]
        [Column("title")]
        public string Title { get; set; }
        [DataMember]
        [Column("body")]
        public string Body { get; set; }
        [DataMember]
        [Column("receipt_time")]
        public DateTime ReceiptTime { get; set; }
    }
}
