namespace TrainingManagementService.Dtos
{
    public class DepartmentDto
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; } = false;

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
