using Ametrin.Command;
using Ametrin.Console;

namespace Ametrin.ConsoleCommandIntegration{
    public sealed class ConsoleCommandLogger : ICommandLogger{
        public void Log(string message) => ConsoleManager.AddMessage(message);
        public void LogWarning(string message) => ConsoleManager.AddMessage(message);
        public void LogError(string message) => ConsoleManager.AddErrorMessage(message);
    }
}