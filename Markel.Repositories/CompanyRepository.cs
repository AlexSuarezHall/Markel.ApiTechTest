using Markel.Data;
using Markel.Data.Models;
using Markel.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Markel.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly MarkelContext _markelContext;

        public CompanyRepository(MarkelContext markelContext)
        {
            _markelContext = markelContext;
        }

        public async Task<Company> GetCompany(int companyId)
        {
            var company = await _markelContext.Companies.Include(x => x.Claims).FirstOrDefaultAsync(x => x.Id == companyId);
            
            if (company is null)
            {
                return null;
            }
            return company;
        }
    }
}
