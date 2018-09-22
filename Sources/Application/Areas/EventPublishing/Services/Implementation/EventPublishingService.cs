using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;
using Mmu.Wss.Application.Areas.EventPublishing.Services.Servants;

namespace Mmu.Wss.Application.Areas.EventPublishing.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "DI")]
    internal class EventPublishingService : IEventPublishingService
    {
        private readonly IEventReceiverFactory _eventReceiverFactory;

        public EventPublishingService(IEventReceiverFactory eventReceiverFactory)
        {
            _eventReceiverFactory = eventReceiverFactory;
        }

        public async Task PublishKeyboardEventAsync(KeyboardInput keyboardInput)
        {
            var receivers = _eventReceiverFactory.CreateApplicableKeyboardReceivers(keyboardInput);
            var receivingTasks = receivers.Select(r => r.ReceiveAsync(keyboardInput));
            await Task.WhenAll(receivingTasks);
        }

        public async Task PublishMouseEventAsync(MouseInput mouseInput)
        {
            var receivers = _eventReceiverFactory.CreateApplicableMouseReceivers(mouseInput);
            var receivingTasks = receivers.Select(r => r.ReceiveAsync(mouseInput));
            await Task.WhenAll(receivingTasks);
        }
    }
}