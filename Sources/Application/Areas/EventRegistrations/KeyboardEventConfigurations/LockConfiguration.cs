using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Wss.Application.Areas.Common.Models;

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
            return ScollLockMustBeActive.CheckIfEquals(lockOptions.IsScrollLockActive) &&
                NumLockMustBeActive.CheckIfEquals(lockOptions.IsNumLockActive) &&
                CapsLockMustBeActive.CheckIfEquals(lockOptions.IsCapsLockActive);
        }

        public static LockConfiguration CreateNotApplibable()
        {
            return new LockConfiguration(
                Option.CreateNotApplicable<bool>(),
                Option.CreateNotApplicable<bool>(),
                Option.CreateNotApplicable<bool>());
        }
    }
}