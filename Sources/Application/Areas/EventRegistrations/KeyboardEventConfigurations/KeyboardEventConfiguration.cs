using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Wss.Application.Areas.EventRegistrations.Common.Models;

namespace Mmu.Wss.Application.Areas.EventRegistrations.KeyboardEventConfigurations
{
    public class KeyboardEventConfiguration : IEventConfiguration
    {
        public KeyboardInputKeyConfiguration InputKeyConfiguration { get; }
        public LockConfiguration LockConfiguration { get; }
        public ModifierConfiguration ModifierConfiguration { get; }

        public KeyboardEventConfiguration(KeyboardInputKeyConfiguration inputKeyConfiguration, ModifierConfiguration modifierConfiguration, LockConfiguration lockConfiguration)
        {
            Guard.ObjectNotNull(() => inputKeyConfiguration);
            Guard.ObjectNotNull(() => modifierConfiguration);
            Guard.ObjectNotNull(() => lockConfiguration);

            InputKeyConfiguration = inputKeyConfiguration;
            ModifierConfiguration = modifierConfiguration;
            LockConfiguration = lockConfiguration;
        }

        public bool CheckIfApplicable(KeyboardInput input)
        {
            return InputKeyConfiguration.CheckIfApplicable(input.InputKey) &&
                ModifierConfiguration.CheckIfApplicable(input.Modifiers) &&
                LockConfiguration.CheckIfApplicable(input.Locks);
        }
    }
}