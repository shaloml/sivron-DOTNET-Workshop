



using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

var serviceProvider = new ServiceCollection()
.AddLogging(options =>
{
    options.ClearProviders();
    options.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    options.AddNLog("nlog.config");
}).BuildServiceProvider();

// Get logger
var logger = serviceProvider.GetService<ILogger<Program>>();

// Use logger
Console.WriteLine("**********************\n\n");
logger.LogTrace("This is an trace log.");
logger.LogDebug("This is an debug log.");
logger.LogInformation("This is an information log.");
logger.LogWarning("This is a warning log.");
logger.LogError("This is an error log.");
logger.LogCritical("This is a critical log.");


Console.WriteLine("**********************\n\n");
using (logger.BeginScope(new Dictionary<string, object>
{
    ["ScopeId"] = Guid.NewGuid(),
    ["UserId"] = 12345,
    ["Operation"] = "DataProcessing"
}))
{
    // Use logger with parameters
    logger.LogTrace("This is a trace log with parameters {Param1} and {Param2}", "value1", "value2");
    logger.LogDebug("This is a debug log with parameters {Param1} and {Param2}", "value3", "value4");
    logger.LogInformation("This is an information log with parameters {Param1} and {Param2}", "value5", "value6");
    logger.LogWarning("This is a warning log with parameters {Param1} and {Param2}", "value7", "value8");
    logger.LogError("This is an error log with parameters {Param1} and {Param2}", "value9", "value10");
    logger.LogCritical("This is a critical log with parameters {Param1} and {Param2}", "value11", "value12");
}


Console.WriteLine("Logs have been written. Press any key to exit.");
Console.ReadKey();

