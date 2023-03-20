using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RoomManagement.Models;

public partial class DbA9626cNaveenkumarmContext : DbContext
{
    public DbA9626cNaveenkumarmContext()
    {
    }

    public DbA9626cNaveenkumarmContext(DbContextOptions<DbA9626cNaveenkumarmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdvanceCal> AdvanceCals { get; set; }

    public virtual DbSet<AmountDetail> AmountDetails { get; set; }

    public virtual DbSet<Expance> Expances { get; set; }

    public virtual DbSet<FoodDetail> FoodDetails { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<RentDetail> RentDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdvanceCal>(entity =>
        {
            entity.ToTable("AdvanceCal");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<AmountDetail>(entity =>
        {
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Expance>(entity =>
        {
            entity.ToTable("Expance");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Item).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<FoodDetail>(entity =>
        {
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.Property(e => e.Company).HasMaxLength(100);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<RentDetail>(entity =>
        {
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });
        modelBuilder.Entity<QueryResult>(entity =>
        {
            entity.HasNoKey();
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
