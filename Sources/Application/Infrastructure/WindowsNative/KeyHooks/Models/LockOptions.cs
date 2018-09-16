using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Models
{
    public class LockOptions
    {
        public bool IsScrollLockActive { get; }
        public bool IsNumLockActive { get; }
        public bool IsCapsLockActive { get; }

        public LockOptions(
            bool isScrollLockActive,
            bool isNumLockActive,
            bool isCapsLockActive)
        {
            IsScrollLockActive = isScrollLockActive;
            IsNumLockActive = isNumLockActive;
            IsCapsLockActive = isCapsLockActive;
        }
    }
}
