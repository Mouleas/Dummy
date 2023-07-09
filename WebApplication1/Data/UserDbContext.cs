using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasOne(d => d.Dept)
                .WithMany(u => u.Users).HasForeignKey(d => d.DeptId);
        }

        public DbSet<WebApplication1.Models.UserModel>? UserModel { get; set; }

        public DbSet<WebApplication1.Models.DeptModel>? DeptModel { get; set; }

    }
}
