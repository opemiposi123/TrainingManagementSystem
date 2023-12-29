using TrainingManagementService.Enums;

namespace TrainingManagementService.Dtos
{
    public class EmployeeDto
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; } = default!;
        public DateTime ModifiedDate { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public Gender Gender { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
