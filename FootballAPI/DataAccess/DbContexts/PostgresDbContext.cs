using FootballApi.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballApi.DataAccess.DbContexts
{
    public class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all entity mappings
            DbMapper.MapUsers(modelBuilder);
        }
    }
}
