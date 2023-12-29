using Microsoft.AspNetCore.Identity;
using TrainingManagementService.Entities;

namespace ITHelpDesk.Domain.Entities;

public class IdentityCustom
{
    public class Role : IdentityRole, ISoftDeletable, IAuditBase
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedFrom { get; set; }
        public string? ModifiedFrom { get; set; }
    }

    public class UserRoles : IdentityUserRole<string>, ISoftDeletable, IAuditBase
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedFrom { get; set; }
        public string? ModifiedFrom { get; set; }
    }

    public class UserClaims : IdentityUserClaim<string>, ISoftDeletable, IAuditBase
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedFrom { get; set; }
        public string? ModifiedFrom { get; set; }
    }

    public class UserLogins : IdentityUserLogin<string>, ISoftDeletable, IAuditBase
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedFrom { get; set; }
        public string? ModifiedFrom { get; set; }
    }

    public class RoleClaims : IdentityRoleClaim<string>, ISoftDeletable, IAuditBase
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedFrom { get; set; }
        public string? ModifiedFrom { get; set; }
    }

    public class UserTokens : IdentityUserToken<string>, ISoftDeletable, IAuditBase
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedFrom { get; set; }
        public string? ModifiedFrom { get; set; }
    }
}
