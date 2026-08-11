using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolEquipmentHire.Data;

public class SchoolEquipmentContext : IdentityDbContext<AppUser>
    {
        public SchoolEquipmentContext (DbContextOptions<SchoolEquipmentContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> User { get; set; } = default!;

public DbSet<SchoolEquipmentHire.Models.Booking> Booking { get; set; } = default!;

public DbSet<SchoolEquipmentHire.Models.Equipment> Equipment { get; set; } = default!;

public DbSet<SchoolEquipmentHire.Models.Category> Category { get; set; } = default!;
    }
