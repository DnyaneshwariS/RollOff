using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Models.Domain
{
    public class AssignedFrom
    {
        [Key]
        public int Id { get; set; }
        public int UserDetailsId { get; set; }
        public int EmployeeId { get; set; }
        public int RollOffFormId { get; set; }
        public int FeedbackFormId { get; set; }
        public int AssignedTo { get; set; }
    }
}
