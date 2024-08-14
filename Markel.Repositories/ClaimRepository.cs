using Markel.Data;
using Markel.Data.Models;
using Markel.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Markel.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly MarkelContext _markelContext;

        public ClaimRepository(MarkelContext markelContext)
        {
            _markelContext = markelContext;
        }

        public async Task<List<Claim>> GetAllClaims(int companyId)
        {
            return await _markelContext.Claims.Where(x => x.CompanyId == companyId).ToListAsync();
        }

        public async Task<Claim> GetClaim(string ucr)
        {
            var claim = await _markelContext.Claims.FirstOrDefaultAsync(x => x.UCR == ucr);

            if (claim is null)
            {
                return null;
            }
            return claim;
        }

        public async Task<Claim> UpdateClaim(Claim claim)
        {
            var model = await GetClaim(claim.UCR);

            if (model is null)
            {
                return null;
            }
            else
            {
                _markelContext.Entry(model).CurrentValues.SetValues(claim);
                await _markelContext.SaveChangesAsync();
                return claim;
            }
        }
    }
}
