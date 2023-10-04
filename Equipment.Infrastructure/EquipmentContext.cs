using Microsoft.EntityFrameworkCore;

namespace Equipment.Infrastructure;
public sealed class EquipmentContext : DbContext
{
    public EquipmentContext(DbContextOptions<EquipmentContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<EquipmentStatus> EquipmentStatuses { get; set; } = null!;
    public DbSet<Equipment> Equipment { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EquipmentStatus>()
            .ToTable(nameof(EquipmentStatus))
            .HasKey(e => e.Id);
        
        modelBuilder.Entity<Equipment>()
            .ToTable(nameof(Equipment))
            .HasKey(e => e.Id);

        modelBuilder.Entity<Equipment>()
            .HasData(new Equipment { Id = 1, Type = "Injection Molder", Location = "Billund" });
    }
}