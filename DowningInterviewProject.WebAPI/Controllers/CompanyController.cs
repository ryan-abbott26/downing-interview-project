using DowningInterviewProject.API.Services;
using DowningInterviewProject.WebAPI.Models;
using DowningInterviewProject.WebAPI.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DowningInterviewProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController(ILogger<CompanyController> logger, ICompanyService companyService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CompanyModel>>> GetCompanies()
        {
            logger.LogTrace("CompanyController - GetCompanies: Attempting to get company list");

            try
            {
                var companies = await companyService.GetCompanies();
                return companies.Select(c => c.ToModel()).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "CompanyController - GetCompanies: Failed to get company list");
                return StatusCode(500);
            }
        }

        [HttpGet("code")]
        public async Task<ActionResult<bool>> CheckCodeIsUnique(string code)
        {
            logger.LogTrace("CompanyController - CheckCodeIsUnique: Attempting to check company code");

            try
            {
                var companies = await companyService.GetCompanies();
                var exists = companies.Select(c => c.Code).Contains(code);

                return exists;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "CompanyController - CheckCodeIsUnique: Failed to check company code");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> SaveCompany(CompanyModel company)
        {
            logger.LogTrace("CompanyController - SaveCompany: Attempting to save company");

            try
            {
                var success = await companyService.SaveCompany(company.ToModel());
                return success;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "CompanyController - SaveCompany: Failed to save company");
                return StatusCode(500);
            }
        }
    }
}
