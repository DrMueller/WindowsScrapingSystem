using System.IO;
using System.Reflection;
using Mmu.Wss.Application.Areas.EventPublishing.Services;
using StructureMap;

namespace Mmu.Wss.Application.Areas.ContainerInitialization.Services
{
    internal static class ContainerInitializationService
    {
        internal static Container CreateInitializedContainer(Assembly baseAssembly)
        {
            var result = new Container();

            //var relevantAssemblies = AssemblyFetcher.FetchRelevantAssembly(baseAssembly);

            var assemblyDirectory = Path.GetDirectoryName(baseAssembly.Location);

            result.Configure(
                config =>
                {
                    config.Scan(
                        scanner =>
                        {
                            scanner.AssembliesFromPath(assemblyDirectory);
                            scanner.AddAllTypesOf<IEventSubscriber>();
                            scanner.LookForRegistries();
                        });
                });

            return result;
        }
    }
}