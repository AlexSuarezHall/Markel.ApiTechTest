using Markel.Data.Models;

namespace Markel.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompany(int companyId);
    }
}
