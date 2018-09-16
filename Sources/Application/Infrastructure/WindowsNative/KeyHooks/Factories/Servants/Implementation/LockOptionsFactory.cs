using System;
using System.Windows.Forms;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Models;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories.Servants.Implementation
{
    internal class LockOptionsFactory : ILockOptionsFactory
    {
        public LockOptions Create()
        {
            var isCapsLockActive = Convert.ToBoolean(DllImports.GetKeyState(Keys.CapsLock)) & true;
            var isNumLockActive = Convert.ToBoolean(DllImports.GetKeyState(Keys.NumLock)) & true;
            var isScrolLLockActivate = Convert.ToBoolean(DllImports.GetKeyState(Keys.Scroll)) & true;

            return new LockOptions(
                isScrolLLockActivate,
                isNumLockActive,
                isCapsLockActive);
        }
    }
}