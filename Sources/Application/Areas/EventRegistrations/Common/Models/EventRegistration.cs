using System;

namespace Mmu.Wss.Application.Areas.EventRegistrations.Common.Models
{
    internal class EventRegistration
    {
        public Func<IEventConfiguration> ConfigCallback { get; }
        public Type ReceiverType { get; }

        public EventRegistration(Type receiverType, Func<IEventConfiguration> configCallback)
        {
            ReceiverType = receiverType;
            ConfigCallback = configCallback;
        }
    }
}