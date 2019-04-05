using System;
using System.Collections.Generic;
using System.Text;
using GeekHunter.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeekHunter.Infrastructure.Persistance.Contexts
{
    public class AppDbContext : DbContext 
    {
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<CandidateSkill> CandidateSkill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source=../GeekHunter.Infrastructure/GeekHunter.sqlite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");
                entity.Property(e => e.Name).IsRequired();
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate");
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<CandidateSkill>()
                .HasKey(cs => new { cs.CandidateId, cs.SkillId });

            modelBuilder.Entity<CandidateSkill>()
                .HasOne(cs => cs.Candidate)
                .WithMany(c => c.CandidateSkills)
                .HasForeignKey(cs => cs.CandidateId);

            modelBuilder.Entity<CandidateSkill>()
                .HasOne(cs => cs.Skill)
                .WithMany(s => s.CandidateSkills)
                .HasForeignKey(cs => cs.SkillId);
        }

    }
}
