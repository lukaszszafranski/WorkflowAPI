using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Models.ProjectsModels;
using BoardAPI.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace BoardAPI.Data
{
    public class BoardAPIContext : DbContext
    {
        public BoardAPIContext (DbContextOptions<BoardAPIContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                        .HasMany(o => o.Members)
                        .WithOne(i => i.Organization);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
