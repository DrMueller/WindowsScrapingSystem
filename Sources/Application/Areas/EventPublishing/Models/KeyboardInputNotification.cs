using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Models;

namespace Mmu.Wss.Application.Areas.EventPublishing.Models
{
    public class KeyboardInputNotification
    {
        public KeyboardInputNotification(KeyboardInput input)
        {
            Guard.ObjectNotNull(() => input);
            Input = input;
        }

        public KeyboardInput Input { get; }
    }
}