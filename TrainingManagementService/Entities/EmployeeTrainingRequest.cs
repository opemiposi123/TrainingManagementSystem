using System.ComponentModel.DataAnnotations.Schema;
using TrainingManagementService.Enums;

namespace TrainingManagementService.Entities
{
    public class EmployeeTrainingRequest : BaseEntity
    {
        public string EmployeeId { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        public string TrainingTypeId { get; set; }
        public TrainingType TrainingType { get; set; }
        //public Guid TrainingVendorSpecializtionId { get;set; }
        //public TrainingVendorSpecialization? TrainingVendorSpecializtion { get; set; }
        public string DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.Now;
        public string Duration { get; set; } = default!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Budget { get; set; } 
        public ApprovalStatus ApprovalStatus { get; set; }
    }
}
