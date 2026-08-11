using SchoolEquipmentHire.Data;
using System.ComponentModel.DataAnnotations;

namespace SchoolEquipmentHire.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public int UserID { get; set; }
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
