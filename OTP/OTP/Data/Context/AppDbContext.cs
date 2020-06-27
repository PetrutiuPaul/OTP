using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OTP.EntityTypeConfiguration;
using OTP.Models;

namespace OTP.Data.Context
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserSecretConfiguration());
        }

        public DbSet<UserSecret> UserSecrets { get; set; }
    }
}
