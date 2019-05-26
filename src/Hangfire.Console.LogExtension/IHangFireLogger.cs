using Hangfire.Server;
using Microsoft.Extensions.Logging;

namespace Hangfire.Console.LogExtension
{
    public interface IHangFireLogger<out T> : IHangFireLogger, ILogger<T>
    {
    }

    public interface IHangFireLogger : ILogger
    {
        void SetPerformContext(PerformContext performContext);
    }
}