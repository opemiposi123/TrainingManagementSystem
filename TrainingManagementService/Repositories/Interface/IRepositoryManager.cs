namespace TrainingManagementService.Repositories.Interface;

public interface IRepositoryManager
{
    IEmployeeRepository EmployeeRepository { get; }
    IDepartmentRepository DepartmentRepository { get; }
    ITrainingRepository TrainingRepository { get; }
    ITrainingPlanRepository TrainingPlanRepository { get; } 
    ITrainingVendorRepository TrainingVendorRepository { get; }
    IEmployeeTrainingRequestRepository EmployeeTrainingRequestRepository { get; }
    ITrainingTypeRepository TrainingTypeRepository { get; } 
    IUnitOfWork UnitOfWork { get; }
}



