using TrainingManagementService.Enums;

namespace TrainingManagementService.Entities
{
    public class Training : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Budget { get; set; }
        public string Description { get; set; }
        public string? Attachment { get; set; }
        public TrainingStatus TrainingStatus { get; set; }
        public string TrainingTypeId { get; set; }
        public string TrainingVendorSpecializtionId { get; set; }
        public string TrainingVendorId { get; set; }
        public string EmployeeTrainingRequestId { get; set; }
        public string? ApprovingEmployeeId { get; set; }
        public EmployeeTrainingRequest EmployeeTrainingRequest { get; set; }
        public TrainingVendor TrainingVendor { get; set; }

        //public TrainingVendorSpecialization TrainingVendorSpecializtion { get; set; }
        public TrainingType TrainingType { get; set; }
    }
}
