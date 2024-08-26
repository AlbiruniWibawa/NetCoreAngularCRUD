using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NetCoreAngularCRUD.Server.Models;

namespace NetCoreAngularCRUD.Server.Data;

public partial class ESportTeamContext : DbContext
{
    public ESportTeamContext(DbContextOptions<ESportTeamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("players");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.TeamId, "teamId_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Earnings).HasColumnName("earnings");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .HasColumnName("fullname");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nationality)
                .HasMaxLength(255)
                .HasColumnName("nationality");
            entity.Property(e => e.Nickname)
                .HasMaxLength(255)
                .HasColumnName("nickname");
            entity.Property(e => e.TeamId).HasColumnName("teamId");

            entity.HasOne(d => d.Team).WithMany(p => p.Players)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("teamId");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("teams");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Earnings).HasColumnName("earnings");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Region)
                .HasMaxLength(255)
                .HasColumnName("region");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
