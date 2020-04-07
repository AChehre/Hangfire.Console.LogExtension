using Hangfire.Server;
using Microsoft.Extensions.Logging;

namespace Hangfire.Console.LogExtension
{
    public interface IHangfireLogger<out T> : IHangfireLogger, ILogger<T>
    {
    }

    public interface IHangfireLogger : ILogger
    {
        void SetPerformContext(PerformContext performContext);
    }
}