using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Models.DTO
{
    public class RollOffTransactionDto
    {
        public RollOffFormDto RollOffFormDto { get; set; }
        public FeedbackFormDto FeedbackFormDto { get; set; }
        public AssignedFromDto AssignedFromDto { get; set; }
    }   
}
