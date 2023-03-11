using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RoomManagement.Models;

public partial class HappyHomeContext : DbContext
{
    public HappyHomeContext()
    {
    }

    public HappyHomeContext(DbContextOptions<HappyHomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Expance> Expances { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
