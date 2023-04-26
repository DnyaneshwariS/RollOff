using System.ComponentModel.DataAnnotations;

namespace RollOff.Models.DTO
{
    public class TransferedFromDto
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int AssignedFrom { get; set; }
        [Required]
        public bool IsAactivate { get; set; }
        [Required]
        public bool IsTransfered { get; set; }
    }
}
