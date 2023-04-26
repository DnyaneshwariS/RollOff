using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Models.Domain
{
    public class RollOffForm
    {
        [Key]
        public int Id { get; set; }
        public string PrimarySkill { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string OtherReason { get; set; }
        public bool PerformanceIssue { get; set; }
        public bool Resgined { get; set; }
        public bool UnderProbation { get; set; }
        public bool LongLeave { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
    }
}
