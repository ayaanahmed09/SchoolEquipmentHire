using Microsoft.EntityFrameworkCore;
using SchoolEquipmentHire.Models;

namespace SchoolEquipmentHire.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolEquipmentContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SchoolEquipmentContext>>()))
            {
                // Look for any equipments.
                if (context.Equipment.Any())
                {
                    return;   // DB has been seeded
                }
                context.Equipment.AddRange(
                    new Equipment
                    {
                        EquipmentName = "Football",
                        Quantity = 5,
                        Category = "Ball",
                        ImageUrl = "/images/equipments/football.png"
                    },
                    new Equipment
                    {
                        EquipmentName = "Basketball",
                        Quantity = 10,
                        Category = "Ball",
                        ImageUrl = "/images/equipments/Basketball.png"
                    },
                    new Equipment
                    {
                        EquipmentName = "Cone",
                        Quantity = 15,
                        Category = "Other",
                        ImageUrl = "/images/equipments/Cone.png"
                    },
                    new Equipment
                    {
                        EquipmentName = "Tennis Ball",
                        Quantity = 20,
                        Category = "Ball",
                        ImageUrl = "/images/equipments/TennisBall.png"
                    },
                    new Equipment
                    {
                        EquipmentName = "Badmminton Racket",
                        Quantity = 5,
                        Category = "Racket",
                        ImageUrl = "/images/equipments/BadmintonRacket.png"
                    },
                    new Equipment
                    {
                        EquipmentName = "Table Tennis Racket",
                        Quantity = 10,
                        Category = "Racket",
                        ImageUrl = "/images/equipments/TableTennisRacket.png"
                    }
                );
                context.SaveChanges();

               /* // Look for any users.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }
                context.User.AddRange(
                    new User
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        YearLevel = 10,
                         Role = RoleType.Student
                     },
                     new User
                     {
                         FirstName = "Jane",
                         LastName = "Smith",
                         YearLevel = 12,
                         Role = RoleType.Admin
                     } 
                 );
                context.SaveChanges();*/
            }
        }
    }
}