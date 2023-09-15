using MariyaCompany.Application.Abstractions.Entity;
using Microsoft.EntityFrameworkCore;

namespace MariyaCompany.Database.Contexts
{
    public class MariyaCompanyContext : DbContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<CompanyPosition> CompanyPositions { get; set; }

        public MariyaCompanyContext() { Database.EnsureCreated(); }
        public MariyaCompanyContext(DbContextOptions<MariyaCompanyContext> options) : base(options) { Database.EnsureCreated(); }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(c => c.Department)
                .WithMany()
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
               .HasOne(c => c.CompanyPosition)
               .WithMany()
               .HasForeignKey(c => c.CompanyPositionId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
