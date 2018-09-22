using System;
using System.Collections.Generic;
using Mmu.Wss.Application.Areas.EventReceiving.Services;
using Mmu.Wss.Application.Areas.EventRegistrations.Common.Models;
using Mmu.Wss.Application.Areas.EventRegistrations.KeyboardEventConfigurations;
using Mmu.Wss.Application.Areas.EventRegistrations.MouseEventConfigurations;

namespace Mmu.Wss.Application.Areas.EventRegistrations.Common.Services
{
    public abstract class EventRegistrationService
    {
        private List<EventRegistration> _registrations = new List<EventRegistration>();
        internal IReadOnlyCollection<EventRegistration> Registrations => _registrations;

        protected void ForKeyboardInput<TReceiver>(Func<KeyboardEventConfiguration> configCallback) where TReceiver : IKeyboardEventReceiver
        {
            _registrations.Add(new EventRegistration(typeof(TReceiver), configCallback));
        }

        protected void ForMouseInput<TReceiver>(Func<MouseEventConfiguration> configCallback) where TReceiver : IMouseEventReceiver
        {
            _registrations.Add(new EventRegistration(typeof(TReceiver), configCallback));
        }
    }
}