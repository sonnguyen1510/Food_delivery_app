using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models.EF.MoneyManagerService;

namespace MoneyManagerService.EF.MoneyManagerService;

public partial class MoneymanagerContext : DbContext
{
    public MoneymanagerContext()
    {
    }

    public MoneymanagerContext(DbContextOptions<MoneymanagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserTransaction> UserTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=money.csiq9islyahz.ap-southeast-2.rds.amazonaws.com;Database=moneymanager; User=admin; Password=12345678; MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC071EDE03EC");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");
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
            entity.Property(e => e.Username)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserTran__3214EC070759953F");

            entity.ToTable("UserTransaction");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Amount).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.CreDate).HasColumnType("date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.TransIcon)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.TransType)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnType("numeric(18, 0)");

            entity.HasOne(d => d.User).WithMany(p => p.UserTransactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("UserTrans");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
