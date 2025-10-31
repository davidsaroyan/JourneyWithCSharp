using FootballApi.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballApi.DataAccess
{
    public static class DbMapper
    {
        public static void MapUsers(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<User>();

            entity.ToTable("Users");

            // Primary key
            entity.HasKey(x => x.Id);

            // Columns
            entity.Property(x => x.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(x => x.UserName)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(x => x.Password)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(x => x.FirstName)
                  .HasMaxLength(50);

            entity.Property(x => x.LastName)
                  .HasMaxLength(50);

            // Seed default user
            entity.HasData(new User
            {
                Id = 1,
                UserName = "admin",
                Password = "admin123",
                FirstName = "Default",
                LastName = "Admin"
            });
        }
    }
}
