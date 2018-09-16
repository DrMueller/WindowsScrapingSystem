using System.Threading.Tasks;
using Mmu.Wss.Application.Areas.EventPublishing.Models;

namespace Mmu.Wss.Application.Areas.EventPublishing.Services
{
    internal interface IEventPublishingService
    {
        Task PublishAsync(KeyboardInputNotification notification);
    }
}
