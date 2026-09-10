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