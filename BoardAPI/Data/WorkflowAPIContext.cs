using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Models.ProjectsModels;
using BoardAPI.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace BoardAPI.Data
{
    public class WorkflowAPIContext : DbContext
    {
        public WorkflowAPIContext (DbContextOptions<WorkflowAPIContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Organization>()
            //            .HasMany(o => o.Members)
            //            .WithOne(i => i.Organization);

            //modelBuilder.Entity<Project>()
            //            .HasOne(p => p.User)
            //            .WithOne(i => i.Project)
            //            .HasForeignKey<User>(x => x.ProjectID);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
