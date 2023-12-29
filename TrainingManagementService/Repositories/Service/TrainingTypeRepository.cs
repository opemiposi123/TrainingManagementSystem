using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrainingManagementService.Context;
using TrainingManagementService.Entities;
using TrainingManagementService.Repositories.Interface;

namespace TrainingManagementService.Repositories.Service
{
    internal sealed class TrainingTypeRepository : Repository<TrainingType>, ITrainingTypeRepository
    {
        public TrainingTypeRepository(TMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TrainingType>> GetAllAsync(Expression<Func<TrainingType, bool>> expression = default!, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TrainingType>()
                .AsNoTracking()
                .Where(expression)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TrainingType>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<TrainingType>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public override async Task<TrainingType?> GetByIdAsync(string id, CancellationToken cancellationToken = default!)
        {
            return await _context.TrainingTypes
                 .Where(r => r.Id == id)
                 .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
