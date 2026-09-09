using SchoolEquipmentHire.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEquipmentHire.Models
{
    public class Booking
    {
        public int BookingID { get; set; }

        [ForeignKey("AppUser")]
        public string UserID { get; set; }
        public AppUser? User { get; set; }
        public int EquipmentID { get; set; }

        [Required]
        [Display(Name = "Booking Date")]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Required]
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

    }
}
