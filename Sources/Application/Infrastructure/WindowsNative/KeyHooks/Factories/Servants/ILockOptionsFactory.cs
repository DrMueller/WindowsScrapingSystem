using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Models;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories.Servants
{
    internal interface ILockOptionsFactory
    {
        LockOptions Create();
    }
}