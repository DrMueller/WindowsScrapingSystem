using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Wss.Application.Areas.Common.Models;

namespace Mmu.Wss.Application.Areas.EventRegistrations.KeyboardEventConfigurations
{
    public class ModifierConfiguration
    {
        public Option<bool> AltMustBePressed { get; }
        public Option<bool> CtrlMustBepressed { get; }
        public Option<bool> ShiftMustBePressed { get; }

        public ModifierConfiguration(Option<bool> ctrlMustBepressed, Option<bool> shiftMustBePressed, Option<bool> altMustBePressed)
        {
            Guard.ObjectNotNull(() => ctrlMustBepressed);
            Guard.ObjectNotNull(() => shiftMustBePressed);
            Guard.ObjectNotNull(() => altMustBePressed);

            CtrlMustBepressed = ctrlMustBepressed;
            ShiftMustBePressed = shiftMustBePressed;
            AltMustBePressed = altMustBePressed;
        }

        internal bool CheckIfApplicable(ModifierOptions modifierOptions)
        {
            return CtrlMustBepressed.CheckIfEquals(modifierOptions.IsCtrlPressed) &&
                ShiftMustBePressed.CheckIfEquals(modifierOptions.IsShiftPressed) &&
                AltMustBePressed.CheckIfEquals(modifierOptions.IsAltPressed);
        }

        public static ModifierConfiguration CreateNotApplibable()
        {
            return new ModifierConfiguration(
                Option.CreateNotApplicable<bool>(),
                Option.CreateNotApplicable<bool>(),
                Option.CreateNotApplicable<bool>());
        }
    }
}