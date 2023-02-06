
namespace DesafioAutoglass.Common.Interfaces
{
    public interface ILoggerManager<TClass> where TClass : class
    {
        // Logs messages for the flow of the application.
        void LogInfo(string message, params object[] args);

        // Logs messages for abnormal or unexpected events in the application flow.
        void LogWarn(string message, params object[] args);

        // Logs messages for short-term debugging purposes.
        void LogDebug(string message, params object[] args);

        // Logs error messages.
        void LogError(string message, params object[] args);

        // Logs error messages with Exception.
        void LogException(Exception exception, string message, params object[] args);

    }
}

