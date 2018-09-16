using System.Reflection;
using Mmu.Wss.Application.Areas.ContainerInitialization.Services;
using Mmu.Wss.Application.Areas.WindowsEventListening.Services;

namespace Mmu.Wss.Application.Areas.Initialization
{
    public static class InitializationService
    {
        public static void Initialize(Assembly rootAssembly)
        {
            var container = ContainerInitializationService.CreateInitializedContainer(rootAssembly);
            var eventListener = container.GetInstance<IWindowsEventListenerService>();
            eventListener.StartListening();
        }
    }
}