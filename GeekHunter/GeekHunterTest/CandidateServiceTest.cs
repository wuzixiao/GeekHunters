using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GeekHunter.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using GeekHunter.Core.Interfaces;
using GeekHunter.Core.Services;

namespace GeekHunterTest
{
    public class CandidateServiceTest
    {
        [Fact]
        public async Task Get_All_Candidates_Success()
        {
            //Arrange
            var candidates = new List<Candidate>
            {
                new Candidate
                {
                    FirstName = "Tom",
                    LastName = "Liu",
                },
                new Candidate
                {
                    FirstName = "John",
                    LastName = "House",
                },
            };

            var mockRepo = new Mock<ICandidateRepository>();
            mockRepo
                .Setup(repo => repo.GetCandidatesBySkillsAsync(null))
                .ReturnsAsync(candidates);

            var service = new CandidateService(mockRepo.Object);
            //Act
            var ret = await service.GetAllCandidatesAsync();

            //Assert
            Assert.Equal(candidates, ret);
        }

        [Fact]
        public void Find_Candidates_Return_Null()
        {
            //add later
        }

        [Fact]
        public void Find_Candidates_Return_NonEmpty()
        {
            //add later
        }

        [Fact]
        public void Save_Candidates_Success()
        {
            //add later
        }
    }
}
