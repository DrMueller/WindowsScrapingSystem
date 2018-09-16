using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Models;

namespace Mmu.Wss.Application.Areas.EventPublishing.Models
{
    public class NotificationConfiguration
    {
        public NotificationConfiguration(KeyboardInputKey inputKey, ModifierConfiguration modifierOptions)
        {
            Guard.ObjectNotNull(() => inputKey);
            Guard.ObjectNotNull(() => modifierOptions);

            InputKey = inputKey;
            ModifierOptions = modifierOptions;
        }

        public KeyboardInputKey InputKey { get; }
        public ModifierConfiguration ModifierOptions { get; }

        internal bool CheckIfNotificationIsApplicable(KeyboardInputNotification notification)
        {
            return InputKey == notification.Input.InputKey &&
                CheckOption(ModifierOptions.AltMustBePressed, notification.Input.ModifierOptions.IsAltPressed) &&
                CheckOption(ModifierOptions.CtrlMustBepressed, notification.Input.ModifierOptions.IsCtrlPressed) &&
                CheckOption(ModifierOptions.ShiftMustBePressed, notification.Input.ModifierOptions.IsShiftPressed);
        }

        private static bool CheckOption(Option option, bool actualValue)
        {
            if (!option.ApplyOption)
            {
                return true;
            }

            return option.OptionValue == actualValue;
        }
    }
}