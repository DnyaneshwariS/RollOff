using System.ComponentModel.DataAnnotations;

namespace RollOff.Models.DTO
{
    public class AssignedFromDto
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int UserDetailsId { get; set; }
        [Required]
        public int RoleType { get; set; }
    }
}
