using Markel.Data.Models;

namespace Markel.Repositories.Interfaces
{
    public interface IClaimRepository
    {
        Task<Claim> GetClaim(string ucr);
        Task<List<Claim>> GetAllClaims(int companyId);
        Task<Claim> UpdateClaim(Claim claim);
    }
}
