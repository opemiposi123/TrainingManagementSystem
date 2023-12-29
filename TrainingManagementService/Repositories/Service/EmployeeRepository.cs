using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrainingManagementService.Context;
using TrainingManagementService.Entities;
using TrainingManagementService.Repositories.Interface;
using TrainingManagementService.Repositories.Service;

namespace TrainingManagementService.Repositories.Service
{
    internal sealed class EmployeeRepository : IEmployeeRepository
    {
        private readonly TMSDbContext _context;

        public EmployeeRepository(TMSDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            await _context.Set<Employee>().AddAsync(employee, cancellationToken);

            return employee;
        }

        public async Task<Employee?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Employee>().FindAsync(id, cancellationToken);
        }

        public async Task<Employee?> GetAsync(Expression<Func<Employee, bool>> expression = default!, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Employee>().SingleOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<bool> ExistsAsync(Expression<Func<Employee, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Employee>().AnyAsync(expression, cancellationToken);
        }

        public Task RemoveAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Deleted;
            return Task.CompletedTask;
        }

        public Task<Employee> UpdateAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            return Task.FromResult(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> expression = default!, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Employee>()
                .Where(expression)
                .ToListAsync(cancellationToken);
        }

        public Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}