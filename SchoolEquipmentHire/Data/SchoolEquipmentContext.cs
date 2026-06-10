using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolEquipmentHire.Models;

    public class SchoolEquipmentContext : DbContext
    {
        public SchoolEquipmentContext (DbContextOptions<SchoolEquipmentContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolEquipmentHire.Models.User> User { get; set; } = default!;

public DbSet<SchoolEquipmentHire.Models.Booking> Booking { get; set; } = default!;

public DbSet<SchoolEquipmentHire.Models.Equipment> Equipment { get; set; } = default!;

public DbSet<SchoolEquipmentHire.Models.Category> Category { get; set; } = default!;
    }
