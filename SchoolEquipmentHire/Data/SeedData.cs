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
                    },
                    new Equipment
                    {
                        EquipmentName = "Basketball",
                        Quantity = 10,
                        Category = "Ball",
                    },
                    new Equipment
                    {
                        EquipmentName = "Cone",
                        Quantity = 15,
                        Category = "Other",
                    },
                    new Equipment
                    {
                        EquipmentName = "Tennis Ball",
                        Quantity = 20,
                        Category = "Ball",
                    },
                    new Equipment
                    {
                        EquipmentName = "Badmminton Racket",
                        Quantity = 5,
                        Category = "Racket",
                    },
                    new Equipment
                    {
                        EquipmentName = "Table Tennis Racket",
                        Quantity = 10,
                        Category = "Racket",
                    }
                );

                // Look for any categories.
                if (context.Equipment.Any())
                {
                    return;   // DB has been seeded
                }
                context.Category.AddRange(
                    new Category
                    {
                        CategoryName = "Ball",
                        ID = 1,
                    },
                    new Category
                    {
                        CategoryName = "Ball",
                        ID = 1,
                    },
                    new Category
                    {
                        CategoryName = "Cone",
                        ID = 2,
                    },
                    new Category
                    {
                        CategoryName = "Ball",
                        ID = 1,
                    },
                    new Category
                    {
                        CategoryName = "Racket",
                        ID = 3,
                    },
                    new Category
                    {
                        CategoryName = "Racket",
                        ID = 3,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}