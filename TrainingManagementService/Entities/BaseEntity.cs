using MassTransit;
namespace TrainingManagementService.Entities;

public abstract class BaseEntity : ISoftDeletable, IAuditBase
{
    public string Id { get; set; } = NewId.Next().ToSequentialGuid().ToString();
    public bool IsDeleted { get; set; } = false;
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
