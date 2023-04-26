using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Models.Domain
{
    public class TransferedFrom
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int AssignedFrom { get; set; }
        public bool IsAactivate { get; set; }
        public bool IsTransfered { get; set; }
    }
}
