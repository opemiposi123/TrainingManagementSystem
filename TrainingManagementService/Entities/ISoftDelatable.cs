namespace TrainingManagementService.Entities
{
    public class ISoftDelatable
    {
        public bool IsDeleted { get; set; } = false;
    }
}
