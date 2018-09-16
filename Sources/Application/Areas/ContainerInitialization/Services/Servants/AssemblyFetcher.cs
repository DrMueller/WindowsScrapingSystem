using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Mmu.Wss.Application.Areas.EventPublishing.Services;

namespace Mmu.Wss.Application.Areas.ContainerInitialization.Services.Servants
{
    internal static class AssemblyFetcher
    {
        internal static IReadOnlyCollection<Assembly> FetchRelevantAssembly(Assembly rootAssembly)
        {
            var codeDirectory = Path.GetDirectoryName(rootAssembly.Location);
            var eventSubscriberType = typeof(IEventSubscriber);

            var assemblies = Directory.GetFiles(codeDirectory)
                .Select(filePath => new FileInfo(filePath))
                .Select(fileInfo => Assembly.LoadFrom(fileInfo.FullName))
                .Where(assembly => assembly.GetExportedTypes().Any(type => type.IsInterface && eventSubscriberType.IsAssignableFrom(type)))
                .ToList();

            return assemblies;
        }
    }
}