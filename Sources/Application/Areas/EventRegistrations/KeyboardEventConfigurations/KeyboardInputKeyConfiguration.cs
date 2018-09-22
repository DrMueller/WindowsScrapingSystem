using System.Linq;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;

namespace Mmu.Wss.Application.Areas.EventRegistrations.KeyboardEventConfigurations
{
    public class KeyboardInputKeyConfiguration
    {
        private readonly KeyboardInputKey[] _keys;

        public KeyboardInputKeyConfiguration(params KeyboardInputKey[] keys)
        {
            _keys = keys;
        }

        internal bool CheckIfApplicable(KeyboardInputKey inputKey)
        {
            return _keys.Contains(inputKey);
        }
    }
}