using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Application.DependencyInjections
{
    public static class DependencyInjectionApplication
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR( configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjectionApplication).Assembly);
            });
            
        }
    }
}
