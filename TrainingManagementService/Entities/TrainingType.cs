using TrainingManagementService.Enums;

namespace TrainingManagementService.Entities
{
    public class TrainingType : BaseEntity
    {
        public string? Title { get; set; }
        public string ResourcePerson { get; set; }
        public decimal? CostPerHead { get; set; }
        public decimal OverallBudget { get;set }
        public int NoOfTrainees { get; set; }
        public TraningTypeCategory TraningTypeCategory { get; set; }
    }
}
