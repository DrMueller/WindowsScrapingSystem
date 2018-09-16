namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Models
{
    public class ModifierOptions
    {
        public ModifierOptions(
            bool isCtrlPressed,
            bool isAltPressed,
            bool isShiftPressed)
        {
            IsCtrlPressed = isCtrlPressed;
            IsAltPressed = isAltPressed;
            IsShiftPressed = isShiftPressed;
        }

        public bool IsAltPressed { get; }
        public bool IsCtrlPressed { get; }
        public bool IsShiftPressed { get; }
    }
}