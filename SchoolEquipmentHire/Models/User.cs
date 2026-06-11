using System.ComponentModel.DataAnnotations;

namespace SchoolEquipmentHire.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public int YearLevel { get; set; }
        [Required]
        public RoleType Role { get; set; }

    }

    public enum RoleType
    {
        Student,
        Admin
    }
}
