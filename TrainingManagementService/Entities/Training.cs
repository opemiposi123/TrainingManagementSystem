using System.ComponentModel.DataAnnotations.Schema;
using TrainingManagementService.Enums;

namespace TrainingManagementService.Entities
{
    public class Training : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Budget { get; set; }
        public string Description { get; set; }
        public string? Attachment { get; set; }
        public TrainingStatus TrainingStatus { get; set; }

        public string TrainingVendorId { get; set; }
        public string EmployeeTrainingRequestId { get; set; }
        public string? ApprovingEmployeeId { get; set; }
        public EmployeeTrainingRequest EmployeeTrainingRequest { get; set; }
        public TrainingVendor TrainingVendor { get; set; }

        //public string TrainingTypeId { get; set; }
        //[ForeignKey("TrainingTypeId")]
        //public TrainingType TrainingType { get; set; }

        public string TrainingVendorSpecializationId { get; set; }
        //public TrainingVendorSpecialization TrainingVendorSpecializtion { get; set; }
    }
}
