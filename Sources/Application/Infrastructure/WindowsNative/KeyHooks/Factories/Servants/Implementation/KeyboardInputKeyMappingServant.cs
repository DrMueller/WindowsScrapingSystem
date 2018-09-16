using System.Linq;
using System.Windows.Forms;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Models;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories.Servants.Implementation
{
    internal class KeyboardInputKeyMappingServant : IKeyboardInputKeyMappingServant
    {
        public KeyboardInputKey MapFromNativeKey(Keys key)
        {
            return KeyboardInputKey.AllKeys.Single(f => f.NativeRepresentation == key.ToString());
        }
    }
}