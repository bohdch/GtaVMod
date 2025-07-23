using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GtaVMod.Data
{
    public class ModDbContextFactory : IDesignTimeDbContextFactory<ModDbContext>
    {
        public ModDbContext CreateDbContext(string[] args)
        {
            var assemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(assemblyPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ModDbContext>();
            var connectionString = configuration.GetConnectionString("GtaVModDbConnection");

            builder.UseNpgsql(connectionString);

            return new ModDbContext(builder.Options);
        }
    }
}
