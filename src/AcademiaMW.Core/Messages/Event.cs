using MediatR;
using System;

namespace AcademiaMW.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime TimeStamp { get; private set; }
        public Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
