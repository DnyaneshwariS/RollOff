using System.ComponentModel.DataAnnotations;

namespace RollOff.Models.DTO
{
    public class FeedbackFormDto
    {
        [Required]
        public string TechnicalSkill { get; set; }
        public string Communication { get; set; }
        public string RoleCompetance { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public int RelevantExperience { get; set; }
    }
}
