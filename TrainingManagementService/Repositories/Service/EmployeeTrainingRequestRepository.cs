using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrainingManagementService.Context;
using TrainingManagementService.Entities;
using TrainingManagementService.Repositories.Interface;
using TrainingManagementService.Repositories.Service;

namespace TrainingManagementService.Repositories.Service
{
    internal sealed class EmployeeTrainingRequestRepository : Repository<EmployeeTrainingRequest>, IEmployeeTrainingRequestRepository
    {
        public EmployeeTrainingRequestRepository(TMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeeTrainingRequest>> GetAllAsync(Expression<Func<EmployeeTrainingRequest, bool>> expression = default!, CancellationToken cancellationToken = default)
        {
            return await _context.Set<EmployeeTrainingRequest>()
                .AsNoTracking()
                .Where(expression)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<EmployeeTrainingRequest>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<EmployeeTrainingRequest>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public override async Task<EmployeeTrainingRequest?> GetByIdAsync(string id, CancellationToken cancellationToken = default!)
        {
            return await _context.EmployeeTrainingRequests
                 .Where(r => r.Id == id)
                 .FirstOrDefaultAsync(cancellationToken);
        }
    }
}


