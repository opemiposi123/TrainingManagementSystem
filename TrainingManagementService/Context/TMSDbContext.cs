using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainingManagementService.Entities;

namespace TrainingManagementService.Context
{
    public class TMSDbContext : IdentityDbContext<Employee>
    {
        public TMSDbContext(DbContextOptions options) : base(options)
        {

        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            //this.EnforceMultiTenant();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            //this.EnforceMultiTenant();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeTrainingRequest> EmployeeTrainingRequests { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<TrainingVendor> TrainingVendors { get; set; }
        public DbSet<TrainingVendorSpecialization> TrainingVendorSpecializations { get; set; }
    }
}
