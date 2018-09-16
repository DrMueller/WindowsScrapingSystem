using Mmu.Wss.Application.Infrastructure.WindowsNative.Delegates;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Services
{
    public interface IKeyHookService
    {
        void Hook();

        void UnHook();

        event KeyDownEventHandler KeyDown;
        event KeyUpEventHandler KeyUp;
    }
}