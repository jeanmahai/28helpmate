﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace Common.Utility
{
    [XmlRoot("MessageResource")]
    public class MessageResource
    {
        [XmlArray("MessageList")]
        [XmlArrayItem("Message")]
        public List<MessageEntity> MessageList { get; set; }    
    }
}
