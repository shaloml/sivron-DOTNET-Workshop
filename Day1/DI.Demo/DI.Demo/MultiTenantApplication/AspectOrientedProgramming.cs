using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Demo.MultiTenantApplication
{

    public class ServiceResolverAspect
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceResolverAspect(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IService GetService(string subscriptionLevel)
        {
            return subscriptionLevel switch
            {
                "Basic" => _serviceProvider.GetRequiredService<BasicService>(),
                "Premium" => _serviceProvider.GetRequiredService<PremiumService>(),
                _ => throw new ArgumentException("Invalid subscription level")
            };
        }
        public static class AspectOrientedProgramming
        {
            public static void ConfigureServices(IServiceCollection services)
            {
                services.AddTransient<BasicService>();
                services.AddTransient<PremiumService>();
                services.AddSingleton<ServiceResolverAspect>();
                services.AddTransient<ServiceResolverAspectConsumer>();
            }
        }

        public class ServiceResolverAspectConsumer
        {
            private readonly ServiceResolverAspect _serviceResolverAspect;

            public ServiceResolverAspectConsumer(ServiceResolverAspect serviceResolverAspect)
            {
                _serviceResolverAspect = serviceResolverAspect;
            }

            public void ExecuteService(string subscriptionLevel)
            {
                var service = _serviceResolverAspect.GetService(subscriptionLevel);
                service.Execute();
            }
        }
    }


}
