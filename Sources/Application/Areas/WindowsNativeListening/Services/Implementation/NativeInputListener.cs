using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services;
using Mmu.Wss.Application.Areas.EventPublishing.Services;
using Mmu.Wss.Application.Infrastructure.Logging;

namespace Mmu.Wss.Application.Areas.WindowsNativeListening.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "DI")]
    internal class NativeInputListener : INativeInputListener
    {
        private readonly IEventPublishingService _eventPublishingService;
        private readonly IKeyboardHookService _keyboardHookService;
        private readonly IWssLoggingService _loggingService;
        private readonly IMouseHookService _mouseHookService;

        public NativeInputListener(
            IKeyboardHookService keyboardHookService,
            IEventPublishingService eventPublishingService,
            IMouseHookService mouseHookService,
            IWssLoggingService loggingService)
        {
            _keyboardHookService = keyboardHookService;
            _eventPublishingService = eventPublishingService;
            _mouseHookService = mouseHookService;
            _loggingService = loggingService;
        }

        public void StartListening()
        {
            _loggingService.LogInfo("Starting listening..");
            _keyboardHookService.HookKeyboard(OnKeyboardInput);
            _mouseHookService.HookMouse(OnMouseInput);
        }

        private void OnKeyboardInput(KeyboardInput keyboardInput)
        {
            _eventPublishingService.PublishKeyboardEventAsync(keyboardInput);
        }

        private void OnMouseInput(MouseInput mouseInput)
        {
            _eventPublishingService.PublishMouseEventAsync(mouseInput);
        }
    }
}