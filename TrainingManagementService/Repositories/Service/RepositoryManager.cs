using TrainingManagementService.Context;
using TrainingManagementService.Repositories.Interface;

namespace TrainingManagementService.Repositories.Service
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IEmployeeRepository> _lazyEmployeeRepository;
        private readonly Lazy<IDepartmentRepository> _lazyDepartmentRepository;
        private readonly Lazy<ITrainingRepository> _lazyTrainingRepository;
        private readonly Lazy<ITrainingPlanRepository> _lazyTrainingPlanRepository;
        private readonly Lazy<ITrainingVendorRepository> _lazyTrainingVendorRepository;
        private readonly Lazy<ITrainingTypeRepository> _lazyTrainingTypeRepository;
        private readonly Lazy<IEmployeeTrainingRequestRepository> _lazyEmployeeTrainingRequestRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;


        public RepositoryManager(TMSDbContext context)
        {
            _lazyEmployeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(context));

            _lazyDepartmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(context));

            _lazyTrainingRepository = new Lazy<ITrainingRepository>(() => new TrainingRepository(context));

            _lazyTrainingPlanRepository = new Lazy<ITrainingPlanRepository>(() => new TrainingPlanRepository(context));

            _lazyTrainingVendorRepository = new Lazy<ITrainingVendorRepository>(() => new TrainingVendorRepository(context));

            _lazyTrainingTypeRepository = new Lazy<ITrainingTypeRepository>(() => new TrainingTypeRepository(context));

            _lazyEmployeeTrainingRequestRepository = new Lazy<IEmployeeTrainingRequestRepository>(() => new EmployeeTrainingRequestRepository(context));

            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }

        public IEmployeeRepository EmployeeRepository => _lazyEmployeeRepository.Value;
        public IDepartmentRepository DepartmentRepository => _lazyDepartmentRepository.Value;
        public ITrainingRepository TrainingRepository => _lazyTrainingRepository.Value;
        public ITrainingPlanRepository TrainingPlanRepository => _lazyTrainingPlanRepository.Value;
        public ITrainingVendorRepository TrainingVendorRepository => _lazyTrainingVendorRepository.Value;
        public ITrainingTypeRepository TrainingTypeRepository => _lazyTrainingTypeRepository.Value;
        public IEmployeeTrainingRequestRepository EmployeeTrainingRequestRepository => _lazyEmployeeTrainingRequestRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

    }
}
