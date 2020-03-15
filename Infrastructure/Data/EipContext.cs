using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.NewsAggregate;
using ApplicationCore.Entities.SystemAggregate;
using ApplicationCore.Entities.UserAggregate;
using ApplicationCore.Entities.CustomersAggregate;

namespace WeAppEip.Infrastructure.Data
{
    public class EipContext : DbContext
    {
        public EipContext(DbContextOptions<EipContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<RoleModule> RoleModules { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration(new ModuleEntityConfiguration());
        }
    }
}
