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
        private void SetupSkills(AppDbContext context)
        {
            var skill = new Skill
            {
                Name = "Leadership"
            };
            var skill2 = new Skill
            {
                Name = "Public Speech"
            };

            var skill3 = new Skill
            {
                Name = "Distributed System"
            };
            var skill4 = new Skill
            {
                Name = "Algorithm"
            };

            context.AddRange(skill, skill2, skill3, skill4);
            context.SaveChanges();
        }

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
        public async Task Find_Canditates_By_LastName()
        {
            //Arrange
            using (var context = new AppDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                SetupSkills(context);

                var repo = new CandidateRepository(context);
                var candidate = new Candidate
                {
                    FirstName = "Tom",
                    LastName = "Liu",
                };

                await repo.SaveCandidateAsync(candidate, new List<int> { 1, 3, 4 });

                //Act
                var actual = await repo.GetCandidatesByNameAsync("liu");

                //Assert
                Assert.Single(actual);
                context.Database.EnsureDeleted();
            }
        }
        [Fact]
        public async Task Find_Canditates_By_FirstName()
        {
            //Arrange
            using (var context = new AppDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                SetupSkills(context);

                var repo = new CandidateRepository(context);
                var candidate = new Candidate
                {
                    FirstName = "Tom",
                    LastName = "Liu",
                };

                await repo.SaveCandidateAsync(candidate, new List<int> { 1, 3, 4 });

                //Act
                var actual = await repo.GetCandidatesByNameAsync("tom");

                //Assert
                Assert.Single(actual);
                context.Database.EnsureDeleted();
            }
        }
        [Fact]
        public async Task Find_Canditates_By_Skill()
        {
            //Arrange
            using (var context = new AppDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                SetupSkills(context);

                var repo = new CandidateRepository(context);
                var candidate = new Candidate
                {
                    FirstName = "Tom",
                    LastName = "Liu",
                };

                await repo.SaveCandidateAsync(candidate, new List<int> { 1, 3, 4 });

                //Act
                var actual = await repo.GetCandidatesBySkillsAsync("api");

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
                SetupSkills(context);

                var repo = new CandidateRepository(context);
                var candidate = new Candidate
                {
                    FirstName = "Tom",
                    LastName = "Liu",
                };
                var skillIds = new List<int> { 1, 3 };
                //Act
                await repo.SaveCandidateAsync(candidate, skillIds);
                var actual = repo.CandidateCount();

                //Assert
                Assert.Equal(1, actual.Result);
                context.Database.EnsureDeleted();
            }
        }
    }
}
