using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaluGada
{
    class Chatroom : Message
    {
        protected int _chatID;
        protected int _buyerID;
        protected int _sellerID;
        protected List<Message> _message;

        public Chatroom()
        {
            _message = new List<Message>();
        }

        public void sendMSG (Message Message)
        {
            _message.Add(Message);
        }

        protected List<Message> viewChatHistory()
        {
            return _message;
        }
    }
}
