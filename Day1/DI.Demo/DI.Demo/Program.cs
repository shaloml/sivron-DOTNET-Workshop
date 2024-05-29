using DI.App;
using DI.Demo.MultiTenantApplication;
using DI.Infra;
using Microsoft.Extensions.DependencyInjection;
using static DI.Demo.MultiTenantApplication.ServiceResolverAspect;

#region Demo1
//var services = new ServiceCollection();
//services.AddTransient<IUserRepository, UserRepository>();
//services.ConfigureServices();
//var serviceProvider = services.BuildServiceProvider();
//var userSrv = serviceProvider.GetRequiredService<IUserService>();
//Console.WriteLine(userSrv.GetUserName(123)); 
#endregion

#region NamedServices
//var services = new ServiceCollection();
//NamedServices.ConfigureServices(services);

//var serviceProvider = services.BuildServiceProvider();
//var myServiceConsumer = serviceProvider.GetRequiredService<MyNamedServicesConsumer>();
//myServiceConsumer.ExecuteService("Premium"); 
#endregion

var services = new ServiceCollection();
AspectOrientedProgramming.ConfigureServices(services);

var serviceProvider = services.BuildServiceProvider();
var serviceResolverAspectConsumer = serviceProvider.GetRequiredService<ServiceResolverAspectConsumer>();
serviceResolverAspectConsumer.ExecuteService("Premium");



Console.ReadKey();


