using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaluGada.model
{
    public class Message
    {
        public int UserId { get; set; }
        public string Content { get; set; }
        public string TimestampWithOffset
        {
            get
            {
                return Timestamp.AddHours(7).ToString("HH:mm");
            }
        }
        public DateTime Timestamp { get; set; }
        public bool IsUserMessage { get; set; }
    }
}
