using System.ComponentModel.DataAnnotations;

namespace RollOff.Models.DTO
{
    public class GetEmployee
    {
        public int GlobalGroupID { get; set; }
        public int? EmployeeNo { get; set; }
        public string? Name { get; set; }
        public string? LocalGrade { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
