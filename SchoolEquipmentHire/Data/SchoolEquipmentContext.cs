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
        public SchoolEquipmentContext (DbContextOptions<SchoolEquipmentContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> User { get; set; } = default!;

public DbSet<SchoolEquipmentHire.Models.Booking> Booking { get; set; } = default!;

public DbSet<SchoolEquipmentHire.Models.Equipment> Equipment { get; set; } = default!;

public DbSet<SchoolEquipmentHire.Models.Category> Category { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
