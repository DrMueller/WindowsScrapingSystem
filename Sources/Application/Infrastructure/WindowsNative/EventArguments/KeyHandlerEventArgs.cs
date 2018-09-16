using System;
using System.Windows.Forms;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.EventArguments
{
    public class KeyHandlerEventArgs : EventArgs
    {
        public KeyHandlerEventArgs(Keys key)
        {
            Key = key;
        }

        public Keys Key { get; set; }
    }
}