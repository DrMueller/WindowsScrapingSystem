using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;
using Mmu.Wss.Application.Areas.EventReceiving.Services;
using Mmu.Wss.Application.Areas.EventRegistrations.Common.Services;
using Mmu.Wss.Application.Areas.EventRegistrations.KeyboardEventConfigurations;
using Mmu.Wss.Application.Areas.EventRegistrations.MouseEventConfigurations;

namespace Mmu.Wss.Application.Areas.EventPublishing.Services.Servants.Implementation
{
    internal class EventReceiverFactory : IEventReceiverFactory
    {
        private readonly IProvisioningService _provisioningService;
        private readonly EventRegistrationService[] _registrationServices;

        public EventReceiverFactory(
            EventRegistrationService[] registrationServices,
            IProvisioningService provisioningService)
        {
            _registrationServices = registrationServices;
            _provisioningService = provisioningService;
        }

        public IReadOnlyCollection<IKeyboardEventReceiver> CreateApplicableKeyboardReceivers(KeyboardInput keyboardInput)
        {
            var inputType = typeof(IEventReceiver<KeyboardInput>);

            return _registrationServices.SelectMany(regService => regService.Registrations)
                .Where(reg => inputType.IsAssignableFrom(reg.ReceiverType))
                .Where(reg => ((KeyboardEventConfiguration)reg.ConfigCallback()).CheckIfApplicable(keyboardInput))
                .Select(reg => _provisioningService.GetService(reg.ReceiverType))
                .Cast<IKeyboardEventReceiver>()
                .ToList();
        }

        public IReadOnlyCollection<IMouseEventReceiver> CreateApplicableMouseReceivers(MouseInput mouseInput)
        {
            var inputType = typeof(IEventReceiver<MouseInput>);

            return _registrationServices.SelectMany(regService => regService.Registrations)
                .Where(reg => inputType.IsAssignableFrom(reg.ReceiverType))
                .Where(reg => ((MouseEventConfiguration)reg.ConfigCallback()).CheckIfApplicable(mouseInput))
                .Select(reg => _provisioningService.GetService(reg.ReceiverType))
                .Cast<IMouseEventReceiver>()
                .ToList();
        }
    }
}