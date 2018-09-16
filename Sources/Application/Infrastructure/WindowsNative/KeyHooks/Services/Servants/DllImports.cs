using System;
using System.Runtime.InteropServices;
using Mmu.Wss.Application.Infrastructure.WindowsNative.Delegates;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Services.Servants
{
    internal static class DllImports
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr SetWindowsHookEx(
            int idHook, LowLevelKeyboardProc callback, IntPtr hInstance,
            uint threadId);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hInstance);
    }
}