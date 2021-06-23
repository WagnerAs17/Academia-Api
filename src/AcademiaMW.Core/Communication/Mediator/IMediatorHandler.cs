﻿using AcademiaMW.Core.Messages;
using System.Threading.Tasks;

namespace AcademiaMW.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;

    }
}
