﻿using System;
using System.Globalization;
using Hangfire.Server;
using Microsoft.Extensions.Logging;

namespace Hangfire.Console.LogExtension
{
    public class HangfireLogger : IHangfireLogger
    {
        protected readonly ILogger Logger;
        protected readonly ConsoleLoggerOptions Options;
        protected PerformContext PerformContext;

        public HangfireLogger(ILogger logger, ConsoleLoggerOptions options)
        {
            Options = options;
            Logger = logger;
        }

        public void SetPerformContext(PerformContext performContext)
        {
            PerformContext = performContext;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
                                Func<TState, Exception, string> formatter)
        {
            var textColor = Options.GetColor(logLevel);


            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                                     CultureInfo.InvariantCulture);

            PerformContext.WriteLine(textColor,
                                     $"[{timestamp}] {logLevel.ToString()} - {eventId.Id} - {formatter(state, exception)}");

            Logger.Log(logLevel, eventId, state, exception, formatter);
        }


        public bool IsEnabled(LogLevel logLevel)
        {
            return Logger.IsEnabled(logLevel);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return Logger.BeginScope(state);
        }
    }


    public class HangfireLogger<T> : HangfireLogger, IHangfireLogger<T>
    {
        private readonly ILogger<T> _logger;


        public HangfireLogger(ILogger<T> logger, ConsoleLoggerOptions options) : base(logger, options)
        {
            _logger = logger;
        }
    }
}