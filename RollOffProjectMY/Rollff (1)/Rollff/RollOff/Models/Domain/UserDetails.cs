using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff.Models.Domain
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
