using System.Linq;
using System.Threading.Tasks;
using Mmu.Wss.Application.Areas.EventPublishing.Models;

namespace Mmu.Wss.Application.Areas.EventPublishing.Services.Implementation
{
    internal class EventPublishingService : IEventPublishingService
    {
        private readonly IEventSubscriber[] _eventSubscribers;

        public EventPublishingService(IEventSubscriber[] eventSubscribers)
        {
            _eventSubscribers = eventSubscribers;
        }

        public async Task PublishAsync(KeyboardInputNotification notification)
        {
            var tasks = _eventSubscribers
                .Where(subs => subs.NotificationConfiguration.CheckIfNotificationIsApplicable(notification))
                .Select(subs => subs.Receive(notification));
            await Task.WhenAll(tasks);
        }
    }
}