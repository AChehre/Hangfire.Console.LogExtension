# Hangfire.Console.LogExtension

[![Build status](https://ci.appveyor.com/api/projects/status/pb6206ush618h7a9/branch/master?svg=true)](https://ci.appveyor.com/project/AChehre/hangfire-console-logextension/branch/master)
[![NuGet](https://img.shields.io/nuget/v/Hangfire.Console.LogExtension.svg)](https://www.nuget.org/packages/Hangfire.Console.LogExtension/)

Hangfire.Console.LogExtension is an extension for Hangfire.Console package that provides a wrapper on ILogger for logging on Hangfire.Console and .Net log provider at the same time.

## Setup

In .NET Core's Startup.cs:
```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddHangfire(config =>
    {
        config.UseSqlServerStorage("connectionSting");
        config.UseConsoleLogger();
    });
}
```

**NOTE**: If you have Dashboard and Server running separately, 
you'll need to call `UseConsole()` on both.

### Additional options

As usual, you may provide additional options for `UseConsoleLogger()` method.
In the options you can set every color of log levels as you want.

**NOTE**: After you initially add Hangfire.Console (or change the options above) you may need to clear browser cache, as generated CSS/JS can be cached by browser.

## Log

Hangfire.Console provides extension methods on `PerformContext` object, 
hence you'll need to add it as a job argument and you need to set on your logger.


**NOTE**: Like `IJobCancellationToken`, `PerformContext` is a special argument type which Hangfire will substitute automatically. You should pass `null` when enqueuing a job.

Now you can write to console:

```c#
IHangFireLogger logger

public void TaskMethod(PerformContext context)
{
    logger.SetPerformContext(context);
	
	logger.LogInformation("Log Information");
	logger.LogDebug("Log Debug");
	logger.LogError("Log Error");
	
}
```

## Progress bars

Hangfire.Console has a feature that it shows a nice progress bar on console, and I am still working on it
