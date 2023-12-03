using System.ComponentModel;

namespace TrainingManagementService.Enums
{
    public enum TrainingPlatForm
    {
        Hybrid,
        Virtual,
        Inperson
    }

    public enum Specialization
    {
        [Description("SoftSkills")]
        SoftSkills = 1,
        [Description("TechnicalSkills")]
        TechnicalSkills,
        [Description("Compliance")]
        Compliance,
        [Description("Safety And Risk")]
        SafetyAndRisk,
        [Description("Product")]
        Product,
        [Description("Diversity, Equity and Inclusion")]
        DiversityEquityAndInclusion,
        [Description("Leadership")]
        Leadership,
        [Description("Orientation")]
        Orientation
    }
    public enum TraningTypeCategory
    {
        Internal = 1,
        External
    }

    public enum PlanStatus
    {
        Active = 1,
        InActive,
    }

    public enum ReviwerStatus
    {
        Pending = 1,
        Reviewed
    }

   

    public enum NumberOfTraining
    {
        Single = 1,
        Multiple
    }
    public enum AppraisalGap
    {
        Yes = 1,
        No
    }

}
