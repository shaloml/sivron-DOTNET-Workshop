using Exercise3_ConfigurationPractice;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

IConfiguration Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

ServiceCollection services = new ServiceCollection();

services.AddSingleton<IConfiguration>(Configuration);
services.AddTransient<TestService>();
services.Configure<EmailServiceSettings>(Configuration.GetSection("EmailService"));

ServiceProvider serviceProvider = services.BuildServiceProvider();

var testService = serviceProvider.GetRequiredService<TestService>();
testService.Check();