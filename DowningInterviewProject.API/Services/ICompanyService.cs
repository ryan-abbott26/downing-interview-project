using DowningInterviewProject.API.Dto;

namespace DowningInterviewProject.API.Services
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetCompanies();

        Task<bool> SaveCompany(CompanyDto company);
    }
}
