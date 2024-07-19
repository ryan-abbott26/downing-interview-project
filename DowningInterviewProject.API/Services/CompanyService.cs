using DowningInterviewProject.API.Dto;
using DowningInterviewProject.API.Repositories;

namespace DowningInterviewProject.API.Services
{
    public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
    {
        public async Task<List<CompanyDto>> GetCompanies()
        {
            try
            {
                var companies = await companyRepository.GetCompanies();
                return companies;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> SaveCompany(CompanyDto company)
        {
            try
            {
                var success = await companyRepository.SaveCompany(company);
                return success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
