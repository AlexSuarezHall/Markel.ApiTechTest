using Markel.Data.Models;
using Markel.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Markel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository) 
        { 
            _companyRepository = companyRepository;
        }

        [HttpGet("{companyId}")]
        [ProducesResponseType(typeof(Company), 200)]
        public async Task<IActionResult> Get(int companyId)
        {
            var company = await _companyRepository.GetCompany(companyId);

            if (company == null)
            {
                return NotFound($"No companies found with Company Id: {companyId}");
            }

            return Ok(company);
        }
    }
}
