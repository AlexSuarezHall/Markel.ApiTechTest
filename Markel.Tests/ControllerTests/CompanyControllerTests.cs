using Markel.API.Controllers;
using Markel.Data.Models;
using Markel.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Markel.Tests.ControllerTests
{
    public class CompanyControllerTests
    {
        private CompanyController _companyController;
        private ICompanyRepository _mockCompanyRepo;

        [SetUp]
        public void Setup()
        {
            _mockCompanyRepo = Substitute.For<ICompanyRepository>();
            _companyController = new CompanyController(_mockCompanyRepo);
        }

        [TearDown]
        public void TearDown()
        {
            _companyController.Dispose();
        }

        [Test]
        public async Task Get_NoMatchingCompanies_ReturnsNotFound()
        {
            int companyId = 912;
            var response = await _companyController.Get(companyId);
            var result = response as NotFoundObjectResult;

            Assert.That(result.StatusCode, Is.EqualTo(404));
            Assert.That(result.Value, Is.EqualTo($"No companies found with Company Id: {companyId}"));

            await _mockCompanyRepo.Received().GetCompany(companyId);
        }

        [Test]
        public async Task Get_WithMatchingCompany_ReturnsOK()
        {
            int companyId = 1;

            var company = new Company
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

            var response = await _companyController.Get(companyId);
            var result = response as OkObjectResult;
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value.GetType, Is.EqualTo(typeof(Company)));

            await _mockCompanyRepo.Received().GetCompany(companyId);
        }
    }
}