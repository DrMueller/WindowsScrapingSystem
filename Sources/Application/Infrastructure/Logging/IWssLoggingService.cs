using System;

namespace Mmu.Wss.Application.Infrastructure.Logging
{
    internal interface IWssLoggingService
    {
        void LogException(Exception ex);

        void LogInfo(string message);

        void LogLoadedRegistrationServices();

        void LogWarning(string message);
    }
}