using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Models.Domain
{
    public class RollOffTransaction
    {
        public RollOffForm RollOffForm { get; set; }
        public FeedbackForm FeedbackForm { get; set; }
        public AssignedFrom AssignedFrom { get; set; }
    }   
}
