namespace TrainingManagementService.Entities;

public interface IAuditBase
{
    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
