using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Models.Domain
{
    public class ReasonMaster
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
