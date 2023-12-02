using Microsoft.AspNetCore.Identity;
using TrainingManagementService.Enums;

namespace TrainingManagementService.Entities
{
    public class Employee : IdentityUser
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
