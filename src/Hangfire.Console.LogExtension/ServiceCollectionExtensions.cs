using System;
using Microsoft.Extensions.DependencyInjection;

namespace Hangfire.Console.LogExtension
{
    public static class ServiceCollectionExtensions
    {
        public static void UseConsoleLogger(
            this IServiceCollection serviceCollection,
            ConsoleLoggerOptions consoleLoggerOptions = null)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            var options = consoleLoggerOptions ?? new ConsoleLoggerOptions();


            serviceCollection.AddSingleton(options);
            serviceCollection.AddScoped(typeof(IHangfireLogger<>), typeof(HangfireLogger<>));
        }
    }
}