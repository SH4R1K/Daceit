using System;
using System.Collections.Generic;
using DaceItFront.Models;
using Microsoft.EntityFrameworkCore;

namespace DaceItFront.Data;

public partial class DaceitContext : DbContext
{
    public DaceitContext()
    {
    }

    public DaceitContext(DbContextOptions<DaceitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<MatchHasPlayer> MatchHasPlayers { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.IdMatch).HasName("PRIMARY");

            entity.ToTable("match");

            entity.Property(e => e.IdMatch).HasColumnName("id_match");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
        });

        modelBuilder.Entity<MatchHasPlayer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("match_has_player");

            entity.HasIndex(e => e.MatchIdMatch, "fk_match_has_player_match1_idx");

            entity.HasIndex(e => e.PlayerIdPlayer, "fk_match_has_player_player1_idx");

            entity.HasIndex(e => e.IdTeam, "fk_match_has_player_team1_idx");

            entity.Property(e => e.IdTeam).HasColumnName("id_team");
            entity.Property(e => e.IsDire)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("is_dire");
            entity.Property(e => e.IsWin)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("is_win");
            entity.Property(e => e.MatchIdMatch).HasColumnName("match_id_match");
            entity.Property(e => e.PlayerIdPlayer).HasColumnName("player_id_player");

            entity.HasOne(d => d.IdTeamNavigation).WithMany()
                .HasForeignKey(d => d.IdTeam)
                .HasConstraintName("fk_match_has_player_team1");

            entity.HasOne(d => d.MatchIdMatchNavigation).WithMany()
                .HasForeignKey(d => d.MatchIdMatch)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_match_has_player_match1");

            entity.HasOne(d => d.PlayerIdPlayerNavigation).WithMany()
                .HasForeignKey(d => d.PlayerIdPlayer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_match_has_player_player1");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.IdPlayer).HasName("PRIMARY");

            entity.ToTable("player");

            entity.Property(e => e.IdPlayer).HasColumnName("id_player");
            entity.Property(e => e.NamePlayer)
                .HasMaxLength(45)
                .HasColumnName("name_player");
            entity.Property(e => e.PlayerMmr)
                .HasDefaultValueSql("'10'")
                .HasColumnName("player_mmr");
            entity.Property(e => e.SteamId).HasColumnName("steam_id");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.IdTeam).HasName("PRIMARY");

            entity.ToTable("team");

            entity.Property(e => e.IdTeam).HasColumnName("id_team");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
