using Microsoft.Extensions.DependencyInjection;
using App;

var services = new ServiceCollection();
services.AddTransient<Domain.IUserRepository, Infra.UserRepository>();
services.ConfigureService();

IServiceProvider serviceProvider = services.BuildServiceProvider();


var userService = serviceProvider.GetRequiredService<App.IUserService>();

var user = userService.GetUser(123);

Console.WriteLine($"Id:{user.Id}, Name:{user.Name}");

Console.ReadKey();
