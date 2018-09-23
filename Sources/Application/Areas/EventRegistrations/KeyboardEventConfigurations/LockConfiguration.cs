using Mmu.Mlh.LanguageExtensions.Areas.Types.Options;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;

namespace Mmu.Wss.Application.Areas.EventRegistrations.KeyboardEventConfigurations
{
    public class LockConfiguration
    {
        public Option<bool> CapsLockMustBeActive { get; }
        public Option<bool> NumLockMustBeActive { get; }
        public Option<bool> ScollLockMustBeActive { get; }

        public LockConfiguration(Option<bool> scollLockMustBeActive, Option<bool> numLockMustBeActive, Option<bool> capsLockMustBeActive)
        {
            ScollLockMustBeActive = scollLockMustBeActive;
            NumLockMustBeActive = numLockMustBeActive;
            CapsLockMustBeActive = capsLockMustBeActive;
        }

        internal bool CheckIfApplicable(LockOptions lockOptions)
        {
            return ScollLockMustBeActive == lockOptions.IsScrollLockActive &&
                NumLockMustBeActive == lockOptions.IsNumLockActive &&
                CapsLockMustBeActive == lockOptions.IsCapsLockActive;
        }

        public static LockConfiguration CreateNotApplicable()
        {
            return new LockConfiguration(
                Option.CreateNotApplicable<bool>(true),
                Option.CreateNotApplicable<bool>(true),
                Option.CreateNotApplicable<bool>(true));
        }
    }
}