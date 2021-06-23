using MediatR;
using System;

namespace AcademiaMW.Core.Messages
{
    public class Command : Message, IRequest<bool>
    {
        public DateTime TimeStamp { get; set; }
        public Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
