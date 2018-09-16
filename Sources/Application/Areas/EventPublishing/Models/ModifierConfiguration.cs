using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wss.Application.Areas.EventPublishing.Models
{
    public class ModifierConfiguration
    {
        public ModifierConfiguration(Option ctrlMustBepressed, Option shiftMustBePressed, Option altMustBePressed)
        {
            Guard.ObjectNotNull(() => ctrlMustBepressed);
            Guard.ObjectNotNull(() => shiftMustBePressed);
            Guard.ObjectNotNull(() => altMustBePressed);

            CtrlMustBepressed = ctrlMustBepressed;
            ShiftMustBePressed = shiftMustBePressed;
            AltMustBePressed = altMustBePressed;
        }

        public Option AltMustBePressed { get; }
        public Option CtrlMustBepressed { get; }
        public Option ShiftMustBePressed { get; }
    }
}