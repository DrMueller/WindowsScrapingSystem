using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Models;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories
{
    internal interface IWindowsKeyboardInputFactory
    {
        KeyboardInput CreateFromNativeKey(Keys key);
    }
}
