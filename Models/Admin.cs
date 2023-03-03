using System.ComponentModel.DataAnnotations;

namespace adminautentication.Models
{
    public class Admin
    {
        
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress (ErrorMessage ="Invalid Email")]
        
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string RoleName { get; set; }
    }
}
