using Mmu.Mlh.LanguageExtensions.Areas.Types.Options;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;
using Mmu.Wss.Application.Areas.EventRegistrations.Common.Models;

namespace Mmu.Wss.Application.Areas.EventRegistrations.MouseEventConfigurations
{
    public class MouseEventConfiguration : IEventConfiguration
    {
        public Option<MouseInputDirection> InputDirection { get; }
        public MouseInputKey InputKey { get; }

        public MouseEventConfiguration(MouseInputKey inputKey, Option<MouseInputDirection> inputDirection)
        {
            InputKey = inputKey;
            InputDirection = inputDirection;
        }

        internal bool CheckIfApplicable(MouseInput mouseInput)
        {
            return InputKey == mouseInput.InputKey && InputDirection == mouseInput.Direction;
        }
    }
}