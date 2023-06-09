using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Inventory_Manager.Models;

public partial class InventoryDatabaseContext : DbContext
{
    public InventoryDatabaseContext()
    {
    }

    public InventoryDatabaseContext(DbContextOptions<InventoryDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inventory> Inventories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-OOBLJKO\\SQLEXPRESS;Database=Inventory_Database;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("Inventory");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DatePurchased).HasColumnType("date");
            entity.Property(e => e.ItemName).HasMaxLength(50);
            entity.Property(e => e.Quality).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
