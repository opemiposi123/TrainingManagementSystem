using MassTransit;
using TrainingManagementService.Entities;
using TrainingManagementService.Enums;

namespace TrainingManagementService.Dtos
{
    public class TrainingDto
    {
        public string Id { get; set; } 
        public bool IsDeleted { get; set; } 
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Budget { get; set; }
        public string Description { get; set; }
        public string? Attachment { get; set; }
        public TrainingStatus TrainingStatus { get; set; }
        public string TrainingTypeId { get; set; }
        public string TrainingVendorSpecializationId { get; set; }
        public string TrainingVendorId { get; set; }
        public string EmployeeTrainingRequestId { get; set; }
        public string? ApprovingEmployeeId { get; set; }
        public EmployeeTrainingRequest EmployeeTrainingRequest { get; set; }
        public TrainingVendor TrainingVendor { get; set; }
        public TrainingVendorSpecialization TrainingVendorSpecializtion { get; set; }
        public TrainingType TrainingType { get; set; }
    }
}
