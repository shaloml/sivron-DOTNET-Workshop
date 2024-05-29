using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExercise
{
    public interface IService
    {
        string PerformService();
    }

    public class BasicService : IService
    {
        public string PerformService()
        {
            return "Performing basic service.";
        }
    }

    public class PremiumService : IService
    {
        public string PerformService()
        {
            return "Performing premium service.";
        }
    }

    public interface IServiceFactory
    {
        IService CreateService(string subscriptionLevel);
    }

    public class ServiceFactory : IServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IService CreateService(string subscriptionLevel)
        {
            return subscriptionLevel switch
            {
                "Basic" => _serviceProvider.GetRequiredService<BasicService>(),
                "Premium" => _serviceProvider.GetRequiredService<PremiumService>(),
                _ => throw new ArgumentException("Invalid subscription level")
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            // Usage examples:
            // 3. Multiple Registrations
            MultipleRegistrationsExample(serviceProvider);

            // 4. Service Locator
            ServiceLocatorExample(serviceProvider);

            // 5. Multi-Tenant Application
            MultiTenantApplicationExample(serviceProvider);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IServiceFactory, ServiceFactory>();

            // Multiple Registrations

            services.AddTransient<IService, BasicService>();
            services.AddTransient<IService, PremiumService>();
            services.AddTransient< BasicService>();
            services.AddTransient< PremiumService>();
        }

        private static void MultipleRegistrationsExample(IServiceProvider serviceProvider)
        {
            Console.WriteLine("\n3. Multiple Registrations");
            var services = serviceProvider.GetServices<IService>();
            foreach (var service in services)
            {
                Console.WriteLine( service.PerformService());
            }
        }

        private static void ServiceLocatorExample(IServiceProvider serviceProvider)
        {
            Console.WriteLine("\n4. Service Locator");
            var service = serviceProvider.GetService<IService>();
            Console.WriteLine(service.PerformService());
        }

        private static void MultiTenantApplicationExample(IServiceProvider serviceProvider)
        {
            Console.WriteLine("\n5. Multi-Tenant Application");
            var factory = serviceProvider.GetService<IServiceFactory>();
            var service = factory.CreateService("Premium");
            Console.WriteLine(service.PerformService());
        }
    }
}
