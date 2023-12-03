namespace TrainingManagementService.Entities
{
    public class TrainingVendor : BaseEntity
    {
        public string VendorName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public string Website { get; set; } = default!;
        public int CountOfSpecialization { get; set; }
        public Guid TrainingVendorSpecializationId { get; set; }
        public ICollection<TrainingVendorSpecialization> TrainingVendorSpecialization { get; set; } = new HashSet<TrainingVendorSpecialization>();
    }
}
