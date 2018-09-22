using System.Threading.Tasks;

namespace Mmu.Wss.Application.Areas.EventReceiving.Services
{
    public interface IEventReceiver<TInput>
    {
        Task ReceiveAsync(TInput input);
    }
}