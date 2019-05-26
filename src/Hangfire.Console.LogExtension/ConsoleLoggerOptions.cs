using Microsoft.Extensions.Logging;
namespace Hangfire.Console.LogExtension
{
    /// <summary>Configuration options for console logger.</summary>
    public class ConsoleLoggerOptions
    {
        public ConsoleLoggerOptions()
        {
            TraceColor = ConsoleTextColor.Green;

            DebugColor = ConsoleTextColor.Gray;

            InformationColor = ConsoleTextColor.DarkGray;

            WarningColor = ConsoleTextColor.Yellow;

            ErrorColor = ConsoleTextColor.Red;

            CriticalColor = ConsoleTextColor.DarkRed;
            DefaultColor = ConsoleTextColor.White;
        }
        /// <summary>
        /// Trace log color on Hangfire.Console.
        /// </summary>
        public ConsoleTextColor TraceColor { get; set; }
        /// <summary>
        /// Trace log color on Hangfire.Console.
        /// </summary>

        public ConsoleTextColor DebugColor { get; set; }
        /// <summary>
        /// Information log color on Hangfire.Console.
        /// </summary>
        public ConsoleTextColor InformationColor { get; set; }
        /// <summary>
        /// Warning log color on Hangfire.Console.
        /// </summary>
        public ConsoleTextColor WarningColor { get; set; }
        /// <summary>
        /// Error log color on Hangfire.Console.
        /// </summary>
        public ConsoleTextColor ErrorColor { get; set; }
        /// <summary>
        /// Critical log color on Hangfire.Console.
        /// </summary>
        public ConsoleTextColor CriticalColor { get; set; }
        /// <summary>
        /// Default log color on Hangfire.Console.
        /// </summary>
        public ConsoleTextColor DefaultColor { get; set; }


        internal ConsoleTextColor GetColor(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    return TraceColor;
                case LogLevel.Debug:
                    return DebugColor;
                case LogLevel.Information:
                    return InformationColor;
                case LogLevel.Warning:
                    return WarningColor;
                case LogLevel.Error:
                    return ErrorColor;
                case LogLevel.Critical:
                    return CriticalColor;
                case LogLevel.None:
                    return DefaultColor;
                default:
                    return DefaultColor;
            }
        }
    }
}