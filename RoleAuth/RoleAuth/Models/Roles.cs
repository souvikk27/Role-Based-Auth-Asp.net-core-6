using System.ComponentModel.DataAnnotations;

namespace RoleAuth.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
