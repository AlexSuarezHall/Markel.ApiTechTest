using Markel.Data.Models;
using Markel.Repositories.Interfaces;
using NSubstitute;

namespace Markel.Tests.RepositoryTests
{
    public class ClaimRepositoryTests
    {
        private IClaimRepository _mockClaimRepo;

        [SetUp]
        public void Setup()
        {
            _mockClaimRepo = Substitute.For<IClaimRepository>();
        }

        [Test]
        public async Task GetClaim_ReturnsClaim_WithCorrectValues()
        {
            string ucr = Guid.NewGuid().ToString();

            var claim = new Claim()
            {
                UCR = ucr,
                AssuredName = "TEST_NAME",
                ClaimDate = DateTime.Now.AddDays(-7),
                CompanyId = 1,
                ClaimTypeId = 1,
                Closed = false,
                IncurredLoss = 0.1m,
                LossDate = DateTime.Now,
            };

            _mockClaimRepo.GetClaim(ucr).Returns(claim);

            var response = await _mockClaimRepo.GetClaim(ucr);

            Assert.That(response, Is.EqualTo(claim));

            await _mockClaimRepo.Received().GetClaim(ucr);
        }

        [Test]
        public async Task GetAllClaims_ReturnsListOfClaims_WithCorrectValues()
        {
            int companyId = 1;

            List<Claim> claimList = new List<Claim>();

            claimList.Add(new Claim()
            {
                UCR = Guid.NewGuid().ToString(),
                AssuredName = "TEST_NAME",
                ClaimDate = DateTime.Now.AddDays(-7),
                CompanyId = companyId,
                ClaimTypeId = 1,
                Closed = false,
                IncurredLoss = 0.1m,
                LossDate = DateTime.Now,
            });

            claimList.Add(new Claim()
            {
                UCR = Guid.NewGuid().ToString(),
                AssuredName = "TEST_NAME_2",
                ClaimDate = DateTime.Now.AddDays(-7),
                CompanyId = companyId,
                ClaimTypeId = 1,
                Closed = false,
                IncurredLoss = 0.1m,
                LossDate = DateTime.Now,
            });

            _mockClaimRepo.GetAllClaims(companyId).Returns(claimList);

            var response = await _mockClaimRepo.GetAllClaims(companyId);

            Assert.That(response, Is.EqualTo(claimList));

            await _mockClaimRepo.Received().GetAllClaims(companyId);
        }
    }
}