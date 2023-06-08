using System;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace LoggingLibrary
{
    public class LoggerManager
    {
        private readonly ILogger _logger;

        public LoggerManager(IConfiguration configuration)
        {
            _logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        public void LogInformation(string messageTemplate, params object[] propertyValues)
        {
            _logger.Information(messageTemplate, propertyValues);
        }

        public void LogDebug(string messageTemplate, params object[] propertyValues)
        {
            _logger.Debug(messageTemplate, propertyValues);
        }

        public void LogError(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Error(exception, messageTemplate, propertyValues);
        }

        public void CloseAndFlush()
        {
            Log.CloseAndFlush();
        }
    }
}
