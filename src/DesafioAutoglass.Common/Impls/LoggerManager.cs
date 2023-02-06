
using Microsoft.Extensions.Logging;

using DesafioAutoglass.Common.Interfaces;

namespace DesafioAutoglass.Common.Impls
{
    public class LoggerManager<TClass> : ILoggerManager<TClass> where TClass : class
    {
        private readonly ILogger logger;

        public LoggerManager(ILogger<TClass> logger)
        {
            this.logger = logger;
        }

        public void LogDebug(string message, params object[] args)
        {
            this.logger.LogDebug(message, args);
        }

        public void LogInfo(string message, params object[] args)
        {
            this.logger.LogInformation(message, args);
        }

        public void LogWarn(string message, params object[] args)
        {
            this.logger.LogWarning(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            this.logger.LogError(message, args);
        }

        public void LogException(Exception exception, string message, params object[] args)
        {
            this.logger.LogError(exception, message, args);
        }

    }
}
