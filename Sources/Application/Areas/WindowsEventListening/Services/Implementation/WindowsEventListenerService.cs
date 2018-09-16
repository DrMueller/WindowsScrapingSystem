using Mmu.Wss.Application.Areas.EventPublishing.Models;
using Mmu.Wss.Application.Areas.EventPublishing.Services;
using Mmu.Wss.Application.Infrastructure.WindowsNative.EventArguments;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Services;

namespace Mmu.Wss.Application.Areas.WindowsEventListening.Services.Implementation
{
    internal class WindowsEventListenerService : IWindowsEventListenerService
    {
        private readonly IEventPublishingService _eventPublishingService;
        private readonly IWindowsKeyboardInputFactory _inputFactory;
        private readonly IKeyHookService _keyHookService;

        public WindowsEventListenerService(
            IKeyHookService keyHookService,
            IEventPublishingService eventPublishingService,
            IWindowsKeyboardInputFactory inputFactory)
        {
            _keyHookService = keyHookService;
            _eventPublishingService = eventPublishingService;
            _inputFactory = inputFactory;
            keyHookService.KeyDown += GlobalKeyHook_KeyDown;
        }

        public void StartListening()
        {
            _keyHookService.Hook();
        }

        private async void GlobalKeyHook_KeyDown(object sender, KeyHandlerEventArgs e)
        {
            var input = _inputFactory.CreateFromNativeKey(e.Key);
            await _eventPublishingService.PublishAsync(new KeyboardInputNotification(input));
        }
    }
}