using MassTransit;
using TrainingManagementService.Entities;
using TrainingManagementService.Enums;

namespace TrainingManagementService.Dtos
{
    public class TrainingPlanDto
    {
        public string Id { get; set; } 
        public bool IsDeleted { get; set; } = false;

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = default!;
        public string Location { get; set; } = default!;
        public string Platform { get; set; } = default!;
        public string CertificateOfCompletion { get; set; } = default!;
        public string ConnectionLink { get; set; } = default!;
        public AppraisalGap AppraisalGap { get; set; }
        public Specialization Specialization { get; set; }
        public TrainingPlatForm TrainingPlatForm { get; set; }
        public Guid TrainingTypeId { get; set; }
        public TrainingType TrainingType { get; set; }
        public Guid TrainingVendorId { get; set; }
        public TrainingVendor TrainingVendor { get; set; }
    }
}
