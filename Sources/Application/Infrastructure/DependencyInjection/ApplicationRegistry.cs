using Mmu.Wss.Application.Areas.EventPublishing.Services;
using Mmu.Wss.Application.Areas.EventPublishing.Services.Implementation;
using Mmu.Wss.Application.Areas.WindowsEventListening.Services;
using Mmu.Wss.Application.Areas.WindowsEventListening.Services.Implementation;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories.Implementation;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories.Servants;
using Mmu.Wss.Application.Infrastructure.WindowsNative.KeyHooks.Factories.Servants.Implementation;
using StructureMap;

namespace Mmu.Wss.Application.Infrastructure.DependencyInjection
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    scanner.WithDefaultConventions();
                });

            For<IEventPublishingService>().Use<EventPublishingService>().Singleton();
            For<IWindowsEventListenerService>().Use<WindowsEventListenerService>().Singleton();
            For<IWindowsKeyboardInputFactory>().Use<WindowsKeyboardInputFactory>().Singleton();
            For<IModifierOptionsFactory>().Use<ModifierOptionsFactory>().Singleton();
            For<ILockOptionsFactory>().Use<LockOptionsFactory>().Singleton();
            For<IKeyboardInputKeyMappingServant>().Use<KeyboardInputKeyMappingServant>().Singleton();
        }
    }
}