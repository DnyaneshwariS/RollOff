using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Models.DTO
{
    public class RollOffFormDto
    {
        [Required]
        public string PrimarySkill { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Reason { get; set; }
        public string OtherReason { get; set; }
        [Required]
        public bool PerformanceIssue { get; set; }
        [Required]
        public bool Resgined { get; set; }
        [Required]
        public bool UnderProbation { get; set; }
        [Required]
        public bool LongLeave { get; set; }
        [Required]
        public string LeaveType { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
    }
}
