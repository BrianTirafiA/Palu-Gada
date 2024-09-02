using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PaluGada
{
    class Message
    {
        protected int _messageID;
        protected string _content;
        protected int _senderID;
        protected DateTime _timestamp;

        public Message createMessage(string content, int _senderID)
        {
            return Message;
        }
    }
}
