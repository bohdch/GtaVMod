using GTANetworkAPI;
using GtaVMod.Data;
using GtaVMod.Data.Interfaces;
using GtaVMod.Data.Repositories;
using GtaVMod.Interfaces;
using GtaVMod.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace GtaVMod
{
    public static class ServicesContainer
    {
        public static IServiceProvider ServiceProvider;

        public static void Init()
        {
            var services = ConfigureServices();
            ServiceProvider = services.BuildServiceProvider();

            using (var scope = ServiceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ModDbContext>();
                db.Database.Migrate();

                NAPI.Util.ConsoleOutput("[INFO] Db migration applied successfully");
            }
        }

        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            var config = LoadConfiguration();

            services.AddDbContext<ModDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("GtaVModDbConnection")));

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IMoneyRepository, MoneyRepository>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IMoneyService, MoneyService>();

            return services;
        }

        public static IConfiguration LoadConfiguration()
        {
            var assemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(assemblyPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
