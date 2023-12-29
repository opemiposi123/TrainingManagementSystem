﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrainingManagementService.Context;
using TrainingManagementService.Entities;
using TrainingManagementService.Repositories.Interface;

namespace TrainingManagementService.Repositories.Service;

internal sealed class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(TMSDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Department>> GetAllAsync(Expression<Func<Department, bool>> expression = default!, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Department>()
            .AsNoTracking()
            .Where(expression)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Department>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Department>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public override async Task<Department?> GetByIdAsync(string id, CancellationToken cancellationToken = default!)
    {
        return await _context.Departments
             .Where(r => r.Id == id)
             .FirstOrDefaultAsync(cancellationToken);
    }
}
