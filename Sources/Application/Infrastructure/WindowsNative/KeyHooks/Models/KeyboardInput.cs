namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Models
{
    public class KeyboardInput
    {
        public KeyboardInput(
            KeyboardInputKey inputKey,
            LockOptions lockOptions,
            ModifierOptions modifierOptions
        )
        {
            InputKey = inputKey;
            LockOptions = lockOptions;
            ModifierOptions = modifierOptions;
        }

        public KeyboardInputKey InputKey { get; }
        public LockOptions LockOptions { get; }
        public ModifierOptions ModifierOptions { get; }
    }
}