using System;

namespace AcademiaMW.Core.Messages
{
    public class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get;  protected set; }
        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}
