namespace SchoolEquipmentHire.Models
{
    public class User
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public int YearLevel { get; set; }

        public RoleType Role { get; set; }

    }

    public enum RoleType
    {
        Student,
        Admin
    }
}
