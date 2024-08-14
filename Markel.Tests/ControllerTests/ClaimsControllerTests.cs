using Markel.API.Controllers;
using Markel.Data.Models;
using Markel.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Markel.Tests.ControllerTests
{
    public class ClaimsControllerTests
    {
        private ClaimController _claimController;
        private IClaimRepository _mockClaimRepo;

        [SetUp]
        public void Setup()
        {
            _mockClaimRepo = Substitute.For<IClaimRepository>();
            _claimController = new ClaimController(_mockClaimRepo);
        }

        [TearDown]
        public void TearDown()
        {
            _claimController.Dispose();
        }

        [Test]
        public async Task Get_NoMatchingClaims_ReturnsNotFound()
        {
            string claimId = "912";
            var response = await _claimController.GetClaim(claimId);
            var result = response as NotFoundObjectResult;

            Assert.That(result.StatusCode, Is.EqualTo(404));
            Assert.That(result.Value, Is.EqualTo($"No claims found"));

            await _mockClaimRepo.Received().GetClaim(claimId);
        }

        [Test]
        public async Task Get_WithMatchingClaim_ReturnsOK()
        {
            string ucr = Guid.NewGuid().ToString();

            var claim = new Claim
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

            var response = await _claimController.GetClaim(ucr);
            var result = response as OkObjectResult;
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value.GetType, Is.EqualTo(typeof(Claim)));

            await _mockClaimRepo.Received().GetClaim(ucr);
        }
    }
}