namespace TrainingManagementService.Entities
{
    public abstract class BaseEntity : ISoftDelatable
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set;}
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set;}
    }
}
