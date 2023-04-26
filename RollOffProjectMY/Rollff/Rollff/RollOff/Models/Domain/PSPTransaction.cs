using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Models.Domain
{
    public class PSPTransaction
    {
        public Employee Employee { get; set; }
        public bool isActivated { get; set; }
        public bool isTransfered { get; set; }
    }   
}
