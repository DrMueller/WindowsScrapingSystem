using System;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.Delegates
{
    public delegate int LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
}