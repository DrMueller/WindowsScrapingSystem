using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;

namespace Mmu.Wss.Application.Areas.EventPublishing.Services
{
    internal interface IEventPublishingService
    {
        Task PublishKeyboardEventAsync(KeyboardInput keyboardInput);

        Task PublishMouseEventAsync(MouseInput mouseInput);
    }
}