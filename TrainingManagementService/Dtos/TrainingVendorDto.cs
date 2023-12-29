using MassTransit;

namespace TrainingManagementService.Dtos
{
    public class TrainingVendorDto
    {
        public string Id { get; set; } 
        public bool IsDeleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string VendorName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public string Website { get; set; } = default!;
        public string TrainingVendorSpecializationId { get; set; }
        public int CountOfSpecialization { get; set; }
    }
}
