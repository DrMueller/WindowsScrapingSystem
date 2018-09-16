using System.Windows.Forms;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories.Servants;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Models;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories.Implementation
{
    // https://stackoverflow.com/questions/34281223/c-sharp-hook-global-keyboard-events-net-4-0
    internal class WindowsKeyboardInputFactory : IWindowsKeyboardInputFactory
    {
        private readonly IKeyboardInputKeyMappingServant _inputKeyMappingServant;
        private readonly ILockOptionsFactory _lockOptionsFactory;
        private readonly IModifierOptionsFactory _modiferOptionsFactory;

        public WindowsKeyboardInputFactory(
            IKeyboardInputKeyMappingServant inputKeyMappingServant,
            ILockOptionsFactory lockOptionsFactory,
            IModifierOptionsFactory modiferOptionsFactory)
        {
            _inputKeyMappingServant = inputKeyMappingServant;
            _lockOptionsFactory = lockOptionsFactory;
            _modiferOptionsFactory = modiferOptionsFactory;
        }

        public KeyboardInput CreateFromNativeKey(Keys key)
        {
            return new KeyboardInput(
                _inputKeyMappingServant.MapFromNativeKey(key),
                _lockOptionsFactory.Create(),
                _modiferOptionsFactory.Create());
        }
    }
}