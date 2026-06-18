using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SchoolEquipmentHire.Areas.Identity.Pages.Account
{
    public class User: IdentityUser
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        [Range(9, 13, ErrorMessage = "Year level must be between 9 and 13")]
        public int? YearLevel { get; set; }
        [Required]
        public RoleType? Role { get; set; }

    }

    public enum RoleType
    {
        Student,
        Admin
    }
}
