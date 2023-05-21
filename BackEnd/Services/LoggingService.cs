using Microsoft.Extensions.Logging;
using System;

namespace FillForm.Services
{
    public interface ILoggingService
    {
        void LogException(Exception ex);
    }

    public class LoggingService : ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        public void LogException(Exception ex)
        {
            // Implement your logging logic here
            _logger.LogError(ex, "An exception occurred");
        }
    }
}
