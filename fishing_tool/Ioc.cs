using DevExpress.Mvvm.POCO;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing_tool
{
    public interface ITransient { }
    public interface ISingleton { }
    public static class Ioc
    {
        private static readonly IServiceProvider Provider;

        public static T Resolve <T>() => Provider.GetRequiredService<T>();

        static Ioc()
        {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.File("data/log.txt")
                .CreateLogger();


            var services = new ServiceCollection();

            services.Scan(s =>
                s.FromAssemblyOf<ITransient>()
                .AddClasses(x => x.AssignableTo<ITransient>()).AsSelf().WithTransientLifetime()
                .AddClasses(x => x.AssignableTo<ISingleton>()).AsSelf().WithSingletonLifetime()
            );

            Provider = services.BuildServiceProvider();


            foreach ( var service in services.Where(s => s.Lifetime == ServiceLifetime.Singleton))
            {
                Provider.GetRequiredService(service.ServiceType);
            }


        }
    }
}
