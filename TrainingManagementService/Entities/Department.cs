using Microsoft.AspNetCore.Identity;

namespace TrainingManagementService.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
