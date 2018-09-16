using System.Threading.Tasks;
using Mmu.Wss.Application.Areas.EventPublishing.Models;

namespace Mmu.Wss.Application.Areas.EventPublishing.Services
{
    public interface IEventSubscriber
    {
        NotificationConfiguration NotificationConfiguration { get; }

        Task Receive(KeyboardInputNotification notification);
    }
}