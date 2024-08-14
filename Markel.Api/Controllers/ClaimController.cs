using Markel.Data.Models;
using Markel.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Markel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimController : Controller
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimController(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        [HttpGet("{ucr}")]
        [ProducesResponseType(typeof(Claim), 200)]
        public async Task<IActionResult> GetClaim(string ucr)
        {
            var claim = await _claimRepository.GetClaim(ucr);

            if (claim == null)
            {
                return NotFound($"No claims found");
            }

            return Ok(claim);
        }

        [HttpGet("GetAllClaimsForCompany/{companyId}")]
        [ProducesResponseType(typeof(List<Claim>), 200)]
        public async Task<IActionResult> GetAllClaimsForCompany(int companyId)
        {
            var claims = await _claimRepository.GetAllClaims(companyId);

            if (claims == null || claims.Count == 0)
            {
                return NotFound("No claims could be found");
            }

            return Ok(claims);
        }

        [HttpPatch("UpdateClaim")]
        [ProducesResponseType(typeof(Claim), 200)]
        public async Task<IActionResult> UpdateClaim(Claim claim)
        {
            var claims = await _claimRepository.UpdateClaim(claim);

            if (claims == null)
            {
                return BadRequest($"An error occured updating your claim");
            }

            return Ok(claims);
        }
    }
}
