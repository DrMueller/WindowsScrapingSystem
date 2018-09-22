using System.Collections.Generic;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;
using Mmu.Wss.Application.Areas.EventReceiving.Services;

namespace Mmu.Wss.Application.Areas.EventPublishing.Services.Servants
{
    internal interface IEventReceiverFactory
    {
        IReadOnlyCollection<IKeyboardEventReceiver> CreateApplicableKeyboardReceivers(KeyboardInput keyboardInput);

        IReadOnlyCollection<IMouseEventReceiver> CreateApplicableMouseReceivers(MouseInput mouseInput);
    }
}