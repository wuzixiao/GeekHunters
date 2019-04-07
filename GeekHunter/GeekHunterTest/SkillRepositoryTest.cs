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
    public class SkillRepositoryTest
    {
        private readonly  DbContextOptions<AppDbContext> _options = new DbContextOptionsBuilder<AppDbContext>()
                            .UseSqlite(@"Data Source=./GeekHunter.sqlite;")
                            .Options;
        [Fact] 
        public async Task Get_ALL_Skills_Success()
        {
            using (var context = new AppDbContext(_options))
            {
                //Arrange
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var repo = new SkillRepository(context);
                //Act
                var actual = await repo.GetAllSkilllsAsync();
                //Assert
                Assert.Equal(3, actual.Count());
                context.Database.EnsureDeleted();
            }
        }
    }
}
