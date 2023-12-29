using TrainingManagementService.Enums;

namespace TrainingManagementService.Entities
{
    public class TrainingPlan : BaseEntity
    {
        public DateTime Date { get; set; } 
        public string Description { get;set; } = default!;
        public  string Location { get; set; } = default!;
        public  string Platform { get; set; } = default!; 
        public string CertificateOfCompletion { get; set; } = default!;
        public string ConnectionLink { get; set; } = default!;
        public AppraisalGap AppraisalGap { get; set; }
        public Specialization Specialization { get; set; }
        public TrainingPlatForm TrainingPlatForm { get; set; }
        public string TrainingTypeId { get; set; }
        public TrainingType TrainingType { get; set; }
        public string TrainingVendorId { get; set; }
        public TrainingVendor TrainingVendor { get; set; }

        

    }
}
