using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrainingManagementService.Context;
using TrainingManagementService.Entities;
using TrainingManagementService.Repositories.Interface;
using TrainingManagementService.Repositories.Service;

namespace TrainingManagementService.Repositories.Service;

internal sealed class TrainingVendorRepository : Repository<TrainingVendor>, ITrainingVendorRepository
{
    public TrainingVendorRepository(TMSDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TrainingVendor>> GetAllAsync(Expression<Func<TrainingVendor, bool>> expression = default!, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TrainingVendor>()
            .AsNoTracking()
            .Where(expression)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TrainingVendor>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<TrainingVendor>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public override async Task<TrainingVendor?> GetByIdAsync(string id, CancellationToken cancellationToken = default!)
    {
        return await _context.TrainingVendors
             .Where(r => r.Id == id)
             .FirstOrDefaultAsync(cancellationToken);
    }
}

