using Configuration.Demo;
using Configuration.Demo.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.WebSockets;

IConfiguration Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

#region Demo1

ServiceCollection services = new ServiceCollection();
services.AddSingleton<IConfiguration>(Configuration);
services.AddTransient<DemoService>();
ServiceProvider serviceProvider = services.BuildServiceProvider();

var demoService = serviceProvider.GetRequiredService<DemoService>();
Console.WriteLine("**********************");
Console.WriteLine(demoService.GetValue());
Console.WriteLine("**********************");
Console.WriteLine(demoService.GetObjValues());
#endregion


#region Demo2
//ServiceCollection services = new ServiceCollection();
////services.AddSingleton<IConfiguration>(Configuration);
//services.AddTransient<DemoService>();
//services.Configure<FeaturesSettings>(Configuration.GetSection("Features"));

//ServiceProvider serviceProvider = services.BuildServiceProvider();
//var demoService = serviceProvider.GetRequiredService<DemoService>();
//demoService.PrintConfig(); 
#endregion



