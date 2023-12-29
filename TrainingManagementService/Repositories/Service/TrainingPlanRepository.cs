using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrainingManagementService.Context;
using TrainingManagementService.Entities;
using TrainingManagementService.Repositories.Interface;
using TrainingManagementService.Repositories.Service;

namespace TrainingManagementService.Repositories.Service
{
    internal sealed  class TrainingPlanRepository : Repository<TrainingPlan>, ITrainingPlanRepository
    {
        public TrainingPlanRepository(TMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TrainingPlan>> GetAllAsync(Expression<Func<TrainingPlan, bool>> expression = default!, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TrainingPlan>()
                .AsNoTracking()
                .Where(expression)
                .ToListAsync(cancellationToken);
        }


        public async Task<IEnumerable<TrainingPlan>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<TrainingPlan>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public override async Task<TrainingPlan?> GetByIdAsync(string id, CancellationToken cancellationToken = default!)
        {
            return await _context.TrainingPlans
                 .Where(r => r.Id == id)
                 .FirstOrDefaultAsync(cancellationToken);
        }
    }
}


