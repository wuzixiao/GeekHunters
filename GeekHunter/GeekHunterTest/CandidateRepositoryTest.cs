using GeekHunter.Core.Entities;
using GeekHunter.Core.Interfaces;
using GeekHunter.Infrastructure.Persistance.Contexts;
using GeekHunter.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GeekHunterTest
{
    //Entity framework core test
    public class CandidateRepositoryTest
    {
        private readonly  DbContextOptions<AppDbContext> _options = new DbContextOptionsBuilder<AppDbContext>()
                            .UseSqlite(@"Data Source=./GeekHunter.sqlite;")
                            .Options;

        [Fact] 
        public async Task SetUp_Database_Success()
        {
            using (var context = new AppDbContext(_options))
            {
                //Arrange
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var repo = new CandidateRepository(context);

                //Act
                var actual = await repo.CandidateCount();

                //Assert
                Assert.Equal(0, actual);
                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task Get_Canditates_By_Skill()
        {
            //Arrange
            using (var context = new AppDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var repo = new CandidateRepository(context);
                var candidate = new Candidate
                {
                    FirstName = "Tom",
                    LastName = "Liu",
                };
                var skill = new Skill
                {
                    Name = "Leadership"
                };
                var skill2 = new Skill
                {
                    Name = "Public Speech"
                };

                candidate.CandidateSkills = new List<CandidateSkill>
                {
                    new CandidateSkill {
                        Candidate = candidate,
                        Skill = skill
                    },
                    new CandidateSkill {
                        Candidate = candidate,
                        Skill = skill2
                    },

                };
                await repo.SaveCandidateAsync(candidate);

                //Act
                var actual = await repo.GetCandidatesBySkillsAsync(new List<string> { "Leadership", "Public Speech" });

                //Assert
                Assert.Single(actual);
                context.Database.EnsureDeleted();
            }
        }
        [Fact]
        public async Task Save_Canditate_Success()
        {
            //Arrange
            using (var context = new AppDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var repo = new CandidateRepository(context);
                var candidate = new Candidate
                {
                    FirstName = "Tom",
                    LastName = "Liu",
                };
                var skill = new Skill
                {
                    Name = "Leadership"
                };
                candidate.CandidateSkills = new List<CandidateSkill>
                {
                    new CandidateSkill {
                        Candidate = candidate,
                        Skill = skill
                    }
                };
                //Act
                await repo.SaveCandidateAsync(candidate);
                var actual = repo.CandidateCount();

                //Assert
                Assert.Equal(1, actual.Result);
                context.Database.EnsureDeleted();
            }
        }
    }
}
