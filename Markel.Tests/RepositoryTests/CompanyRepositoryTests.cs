using Markel.Data.Models;
using Markel.Repositories.Interfaces;
using NSubstitute;

namespace Markel.Tests.RepositoryTests
{
    public class CompanyRepositoryTests
    {
        private ICompanyRepository _mockCompanyRepo;

        [SetUp]
        public void Setup()
        {
            _mockCompanyRepo = Substitute.For<ICompanyRepository>();
        }

        [Test]
        public async Task GetCompany_ReturnsCompany_WithCorrectValues()
        {
            var companyId = 19;

            var company = new Company()
            {
                Id = companyId,
                Name = "Test Company",
                Address1 = "Test Address 1",
                Address2 = "Test Address 1",
                Address3 = "Test Address 1",
                Postcode = "LS1 5TU",
                Country = "England",
                InsuranceDate = DateTime.Now,
                Active = true
            };

            _mockCompanyRepo.GetCompany(companyId).Returns(company);

            var response = await _mockCompanyRepo.GetCompany(companyId);

            Assert.That(response, Is.EqualTo(company));

            await _mockCompanyRepo.Received().GetCompany(companyId);
        }

        [Test]
        public async Task GetCompany_NoMatchCompany_ReturnsNull()
        {
            var companyId = 55;

            _mockCompanyRepo.GetCompany(companyId).Returns((Company)null);

            var response = await _mockCompanyRepo.GetCompany(companyId);

            Assert.That(response, Is.EqualTo(null));

            await _mockCompanyRepo.Received().GetCompany(companyId);
        }
    }
}