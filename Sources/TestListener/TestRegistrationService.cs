using System.Linq;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;
using Mmu.Wss.Application.Areas.EventRegistrations.Common.Services;
using Mmu.Wss.Application.Areas.EventRegistrations.KeyboardEventConfigurations;
using Mmu.Wss.Application.Areas.EventRegistrations.MouseEventConfigurations;

namespace Mmu.Wss.TestListener
{
    public class TestRegistrationService : EventRegistrationService
    {
        public TestRegistrationService()
        {
            ForKeyboardInput<TestKeyboardReceiver>(
                () => new KeyboardEventConfiguration(
                    new KeyboardInputKeyConfiguration(KeyboardInputKey.A),
                    new ModifierConfiguration(false, false, false),
                    LockConfiguration.CreateNotApplicable()));

            ForKeyboardInput<Test2KeyboardReceiver>(
                () => new KeyboardEventConfiguration(
                    new KeyboardInputKeyConfiguration(KeyboardInputKey.AllKeys.ToArray()),
                    new ModifierConfiguration(true, false, false),
                    new LockConfiguration(false, false, true)));

            ForMouseInput<TestMouseReceiver>(
                () => new MouseEventConfiguration(MouseInputKey.Right, MouseInputDirection.MouseDown));
        }
    }
}