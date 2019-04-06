using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GeekHunter.Core.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace GeekHunter.Infrastructure.Persistance.Contexts
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public AppDbContext() { }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
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
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate");
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
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

            //var candidate = new Candidate
            //{
            //    FirstName = "firstName",
            //    LastName = "lastName",
            //    Id = 1
            //};

            //var skill = new Skill
            //{
            //    Name = "Leadership",
            //    Id = 1
            //};

            //var css = new CandidateSkill
            //{
            //    SkillId = 1,
            //    Skill = skill,
            //    Candidate = candidate,
            //    CandidateId = 1,
            //};

            //modelBuilder.Entity<Skill>().HasData(skill);
            //modelBuilder.Entity<Candidate>().HasData(candidate);
            //modelBuilder.Entity<CandidateSkill>().HasData(css);

            //Add some Skills
            //modelBuilder.Entity<Skill>().HasData(
            //    new Skill
            //    {
            //        Name = "API"
            //    },
            //    new Skill
            //    {
            //        Name = "Leadership"
            //    }
            //);
        }

    }
}
