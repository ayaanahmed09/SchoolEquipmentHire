using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolEquipmentHire.Data;
using SchoolEquipmentHire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SchoolEquipmentContext : IdentityDbContext<AppUser>
{
    public SchoolEquipmentContext(DbContextOptions<SchoolEquipmentContext> options)
        : base(options)
    {
    }


    public DbSet<SchoolEquipmentHire.Models.Booking> Booking { get; set; } = default!;

    public DbSet<SchoolEquipmentHire.Models.Equipment> Equipment { get; set; } = default!;

    public DbSet<SchoolEquipmentHire.Models.Category> Category { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Equipment>().HasData(
        new Equipment { ID = 1, EquipmentName = "Football", Category = "Ball", Quantity = 5, ImageUrl = "~/images/equipments/Football.png" },
        new Equipment { ID = 2, EquipmentName = "Basketball", Category = "Ball", Quantity = 10, ImageUrl = "~/images/equipments/Basketball.png" },
        new Equipment { ID = 3, EquipmentName = "Table Tennis Racket", Category = "Racket", Quantity = 10, ImageUrl = "~/images/equipments/TableTennisRacket.png" },
        new Equipment { ID = 4, EquipmentName = "Tennis Ball", Category = "Ball", Quantity = 20, ImageUrl = "~/images/equipments/TennisBall.png" },
        new Equipment { ID = 5, EquipmentName = "Badminton Racket", Category = "Racket", Quantity = 5, ImageUrl = "~/images/equipments/BadmintonRacket.png" },
        new Equipment { ID = 6, EquipmentName = "Cone", Category = "Other", Quantity = 15, ImageUrl = "~/images/equipments/Cone.png" }
        );
    }
}
