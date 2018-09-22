using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;
using Mmu.Wss.Application.Areas.EventPublishing.Services;
using Mmu.Wss.Application.Infrastructure.Logging;

namespace Mmu.Wss.Application.Areas.WindowsNativeListening.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "DI")]
    internal class NativeInputListener : INativeInputListener
    {
        private readonly IEventPublishingService _eventPublishingService;
        private readonly IKeyboadHookService _keyboardHookService;
        private readonly IWssLoggingService _loggingService;

        public NativeInputListener(
            IKeyboadHookService keyboardHookService,
            IEventPublishingService eventPublishingService,
            IWssLoggingService loggingService)
        {
            _keyboardHookService = keyboardHookService;
            _eventPublishingService = eventPublishingService;
            _loggingService = loggingService;
        }

        public void StartListening()
        {
            _loggingService.LogInfo("Starting listening..");
            _keyboardHookService.HookKeyboard(OnKeyboardInput);
        }

        public void StopListening()
        {
            _loggingService.LogInfo("Stopping listening..");

            // Implement in NetFrameworkExtensions
        }

        private void OnKeyboardInput(KeyboardInput keyboardInput)
        {
            _eventPublishingService.PublishKeyboardEventAsync(keyboardInput);
        }
    }
}