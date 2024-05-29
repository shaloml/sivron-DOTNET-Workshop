
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

//.AddLogging(configure =>
//{
//    configure.AddConsole();

//})
//.BuildServiceProvider();

IConfiguration Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

var serviceProvider = new ServiceCollection()
.AddLogging(options =>
 {
     options.AddConsole();
     options.AddEventSourceLogger();
     options.AddConfiguration(Configuration.GetSection("Logging"));
 }).BuildServiceProvider();

// Get logger
var logger = serviceProvider.GetService<ILogger<Program>>();

// Use logger
Console.WriteLine( "**********************\n\n" );
logger.LogTrace("This is an trace log.");
logger.LogDebug("This is an debug log.");
logger.LogInformation("This is an information log.");
logger.LogWarning("This is a warning log.");
logger.LogError("This is an error log.");
logger.LogCritical("This is a critical log.");

Console.WriteLine("Logs have been written. Press any key to exit.");
Console.ReadKey();

