using Microsoft.EntityFrameworkCore;
using GtaVMod.Data.Entities;

namespace GtaVMod.Data
{
    public class ModDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public ModDbContext(DbContextOptions<ModDbContext> options) : base(options)
        {
        }
    }
}
