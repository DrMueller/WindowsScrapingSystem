using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Mmu.Mlh.ApplicationExtensions.Areas.Logging.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Wss.Application.Areas.EventRegistrations.Common.Services;

namespace Mmu.Wss.Application.Infrastructure.Logging.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "DI")]
    internal class WssLoggingService : IWssLoggingService
    {
        private readonly ILoggingService _loggingService;
        private readonly IProvisioningService _provisioningService;

        public WssLoggingService(ILoggingService loggingService, IProvisioningService provisioningService)
        {
            _loggingService = loggingService;
            _provisioningService = provisioningService;
        }

        public void LogException(Exception ex)
        {
            _loggingService.LogException(ex);
        }

        public void LogInfo(string message)
        {
            _loggingService.LogInfo(message);
        }

        public void LogLoadedRegistrationServices()
        {
            var registries = _provisioningService.GetAllServices<EventRegistrationService>();
            var sb = new StringBuilder();

            sb.AppendLine("Registries:");
            foreach (var reg in registries)
            {
                sb.Append(reg.GetType().FullName);
                sb.Append(" in Assembly ");
                sb.AppendLine(reg.GetType().Assembly.FullName);
            }

            _loggingService.LogInfo(sb.ToString());
        }

        public void LogWarning(string message)
        {
            _loggingService.LogWarning(message);
        }
    }
}