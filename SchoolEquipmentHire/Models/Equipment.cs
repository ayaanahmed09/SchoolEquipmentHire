using System.ComponentModel.DataAnnotations;

namespace SchoolEquipmentHire.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }

        [Display(Name = "Equipment Name")]
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }

    }
}
