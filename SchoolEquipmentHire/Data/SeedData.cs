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
                        CategoryID = 1
                    },
                    new Equipment
                    {
                        EquipmentName = "Basketball",
                        Quantity = 10,
                        CategoryID = 2
                    },
                    new Equipment
                    {
                        EquipmentName = "Cone",
                        Quantity = 15,
                        CategoryID = 3
                    },
                    new Equipment
                    {
                        EquipmentName = "Tennis Ball",
                        Quantity = 20,
                        CategoryID = 4
                    },
                    new Equipment
                    {
                        EquipmentName = "Badmminton Racket",
                        Quantity = 5,
                        CategoryID = 5
                    },
                    new Equipment
                    {
                        EquipmentName = "Table Tennis Racket",
                        Quantity = 10,
                        CategoryID = 6
                    }
                );
                context.SaveChanges();
            }
        }
    }
}