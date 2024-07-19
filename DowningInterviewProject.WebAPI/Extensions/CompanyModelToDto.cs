using DowningInterviewProject.API.Dto;
using DowningInterviewProject.WebAPI.Models;

namespace DowningInterviewProject.WebAPI.Extensions
{
    public static class CompanyModelToDto
    {
        public static CompanyDto ToModel(this CompanyModel company)
        {
            return new CompanyDto
            {
                Name = company.Name,
                Code = company.Code,
                SharePrice = company.SharePrice,
                CreatedDate = company.CreatedDate
            };
        }
    }
}