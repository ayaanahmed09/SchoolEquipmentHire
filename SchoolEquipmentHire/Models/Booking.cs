using System.ComponentModel.DataAnnotations;

namespace SchoolEquipmentHire.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int EquipmentID { get; set; }

        [Display(Name = "Booking Date")]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
