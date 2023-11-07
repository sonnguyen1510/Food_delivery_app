using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MoneyManagerService.EF.MoneyManagerService;

public partial class MoneyManagerContext : DbContext
{
    public MoneyManagerContext()
    {
    }

    public MoneyManagerContext(DbContextOptions<MoneyManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=7-166;Database=MoneyManager;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0773E1150D");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Fullname)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TransId)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("TransID");
            entity.Property(e => e.Username)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
