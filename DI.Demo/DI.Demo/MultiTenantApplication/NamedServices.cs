using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Demo.MultiTenantApplication
{
    static class NamedServices
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<BasicService>();
            services.AddTransient<PremiumService>();
            services.AddTransient<Func<string, IService>>(serviceProvider => key =>
            {
                return key switch
                {
                    "Basic" => serviceProvider.GetRequiredService<BasicService>(),
                    "Premium" => serviceProvider.GetRequiredService<PremiumService>(),
                    _ => throw new ArgumentException("Invalid subscription level")
                };
            });
            services.AddTransient<MyNamedServicesConsumer>();
        }

    }
    public class MyNamedServicesConsumer
    {
        private readonly Func<string, IService> _serviceAccessor;

        public MyNamedServicesConsumer(Func<string, IService> serviceAccessor)
        {
            _serviceAccessor = serviceAccessor;
        }

        public void ExecuteService(string subscriptionLevel)
        {
            var service = _serviceAccessor(subscriptionLevel);
            service.Execute();
        }
    }

}
