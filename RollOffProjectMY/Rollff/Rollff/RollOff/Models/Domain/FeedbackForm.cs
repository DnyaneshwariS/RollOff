using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Models.Domain
{
    public class FeedbackForm
    {
        [Key]
        public int Id { get; set; }
        public string TechnicalSkill { get; set; }
        public string Communication { get; set; }
        public string RoleCompetance { get; set; }
        public string Remarks { get; set; }
        public int RelevantExperience { get; set; }
    }
}
