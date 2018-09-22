using Mmu.Wss.Application.Areas.EventPublishing.Services;
using Mmu.Wss.Application.Areas.EventPublishing.Services.Implementation;
using Mmu.Wss.Application.Areas.EventPublishing.Services.Servants;
using Mmu.Wss.Application.Areas.EventPublishing.Services.Servants.Implementation;
using Mmu.Wss.Application.Areas.EventReceiving.Services;
using Mmu.Wss.Application.Areas.EventRegistrations.Common.Services;
using Mmu.Wss.Application.Areas.WindowsNativeListening.Services;
using Mmu.Wss.Application.Areas.WindowsNativeListening.Services.Implementation;
using Mmu.Wss.Application.Infrastructure.Logging;
using Mmu.Wss.Application.Infrastructure.Logging.Implementation;
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
                    scanner.AddAllTypesOf<EventRegistrationService>();
                    scanner.AddAllTypesOf(typeof(IEventReceiver<>));
                    scanner.LookForRegistries();
                    scanner.WithDefaultConventions();
                });

            For<IEventPublishingService>().Use<EventPublishingService>().Singleton();
            For<IEventReceiverFactory>().Use<EventReceiverFactory>().Singleton();
            For<INativeInputListener>().Use<NativeInputListener>().Singleton();

            // Infrastructure
            For<IWssLoggingService>().Use<WssLoggingService>().Singleton();
        }
    }
}