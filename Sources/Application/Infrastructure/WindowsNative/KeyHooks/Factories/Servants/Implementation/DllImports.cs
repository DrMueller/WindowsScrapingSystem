using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories.Servants.Implementation
{
    internal static class DllImports
    {
        [DllImport("user32.dll")]
        internal static extern short GetKeyState(System.Windows.Forms.Keys nVirtKey);
    }
}
