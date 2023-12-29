using TrainingManagementService.Context;
using TrainingManagementService.Repositories.Interface;

namespace TrainingManagementService.Repositories.Service
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TMSDbContext _context;

        public UnitOfWork(TMSDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
