using System.ComponentModel.DataAnnotations.Schema;
using TrainingManagementService.Enums;

namespace TrainingManagementService.Entities
{
    public class TrainingType : BaseEntity
    {
        public string? Title { get; set; }
        public string ResourcePerson { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? CostPerHead { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OverallBudget { get; set; }
        public int NoOfTrainees { get; set; }
        public TraningTypeCategory TraningTypeCategory { get; set; }
        //public ICollection<Training> Trainings { get; set; }

    }

}
