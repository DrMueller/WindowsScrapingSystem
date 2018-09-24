using System.Reflection;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Wss.Application.Areas.WindowsNativeListening.Services;
using Mmu.Wss.Application.Infrastructure.Logging;

namespace Mmu.Wss.Application.Areas.Initialization
{
    public static class BootstrapService
    {
        private static INativeInputListener _nativeInputListener;

        public static void Start(Assembly rootAssembly)
        {
            ContainerInitializationService.CreateInitializedContainer(new AssemblyParameters(rootAssembly, "Mmu.Wss"));
            _nativeInputListener = ProvisioningServiceSingleton.Instance.GetService<INativeInputListener>();
            var loggingService = ProvisioningServiceSingleton.Instance.GetService<IWssLoggingService>();
            loggingService.LogLoadedRegistrationServices();
            _nativeInputListener.StartListening();
        }
    }
}