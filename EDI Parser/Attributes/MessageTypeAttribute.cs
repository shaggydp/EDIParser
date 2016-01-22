using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Attributes
{
    public class MessageTypeAttribute : Attribute
    {
        public string MessageType { get; set; }
        public MessageTypeAttribute(string messageType)
        {
            this.MessageType = messageType;
        }
    }
}
