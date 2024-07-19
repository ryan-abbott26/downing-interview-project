using DowningInterviewProject.API.Dto;

namespace DowningInterviewProject.API.Repositories
{
    public interface ICompanyRepository
    {
        Task<List<CompanyDto>> GetCompanies();

        Task<bool> SaveCompany(CompanyDto company);
    }
}
