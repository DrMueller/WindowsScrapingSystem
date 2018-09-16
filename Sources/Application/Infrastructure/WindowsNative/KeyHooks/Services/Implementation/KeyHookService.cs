using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Mmu.Wss.Application.Infrastructure.WindowsNative.ActionHandling;
using Mmu.Wss.Application.Infrastructure.WindowsNative.Delegates;
using Mmu.Wss.Application.Infrastructure.WindowsNative.EventArguments;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Services.Servants;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Services.Implementation
{
    public class KeyHookService : IKeyHookService
    {
        private LowLevelKeyboardProc _hookedProc;
        private IntPtr _hookId = IntPtr.Zero;

        public KeyHookService()
        {
            _hookedProc = HookProc;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Hook()
        {
            //InvokeActionHandler.HandledInvokeAction(
            //    () =>
            //    {
                    _hookId = DllImports.SetWindowsHookEx(CommandConstants.WH_KEYBOARD_LL, _hookedProc, IntPtr.Zero, 0);
                //});
        }

        public void HookByAppDomain()
        {
            InvokeActionHandler.HandledInvokeAction(
                () =>
                {
                    _hookId = DllImports.SetWindowsHookEx(CommandConstants.WH_KEYBOARD, _hookedProc, IntPtr.Zero, 0);
                });
        }

        public void UnHook()
        {
            InvokeActionHandler.HandledInvokeAction(() => DllImports.UnhookWindowsHookEx(_hookId));
        }

        private void Dispose(bool disposing)
        {
            UnHook();
            _hookedProc = null;
            _hookId = IntPtr.Zero;
        }

        private int HookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return (int)DllImports.CallNextHookEx(_hookId, nCode, wParam, lParam);
            }

            var val = Marshal.ReadInt32(lParam);
            var key = (Keys)val;

            switch (wParam.ToInt32())
            {
                case CommandConstants.WM_KEYDOWN:
                    OnKeyDown(key);
                    break;
                case CommandConstants.WM_KEYUP:
                    OnKeyUp(key);
                    break;
            }

            return (int)DllImports.CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        private void OnKeyDown(Keys key)
        {
            KeyDown?.Invoke(this, new KeyHandlerEventArgs(key));
        }

        private void OnKeyUp(Keys key)
        {
            KeyUp?.Invoke(this, new KeyHandlerEventArgs(key));
        }

        public event KeyDownEventHandler KeyDown;
        public event KeyUpEventHandler KeyUp;

        ~KeyHookService()
        {
            Dispose(false);
        }
    }
}