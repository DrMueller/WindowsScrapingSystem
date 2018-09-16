using System.Windows.Forms;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Models;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories.Servants.Implementation
{
    internal class ModifierOptionsFactory : IModifierOptionsFactory
    {
        public ModifierOptions Create()
        {
            var isShiftPressed = CheckIfActive(DllImports.GetKeyState(Keys.ShiftKey));
            var isCtrlpressed = CheckIfActive(DllImports.GetKeyState(Keys.ControlKey));
            var isAltpressed = CheckIfActive(DllImports.GetKeyState(Keys.Menu));

            return new ModifierOptions(
                isCtrlpressed,
                isAltpressed,
                isShiftPressed);
        }

        private static bool CheckIfActive(short state)
        {
            return state > 1 || state < -1;
        }
    }
}