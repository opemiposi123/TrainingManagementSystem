using MassTransit;
using TrainingManagementService.Enums;

namespace TrainingManagementService.Dtos
{
    public class TrainingTypeDto
    {
        public string Id { get; set; } 
        public bool IsDeleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Title { get; set; }
        public string ResourcePerson { get; set; }
        public decimal? CostPerHead { get; set; }
        public decimal OverallBudget { get; set; }
        public int NoOfTrainees { get; set; }
        public TraningTypeCategory TraningTypeCategory { get; set; }
    }
}
