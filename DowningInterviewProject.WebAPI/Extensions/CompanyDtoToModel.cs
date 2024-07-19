using DowningInterviewProject.API.Dto;
using DowningInterviewProject.WebAPI.Models;

namespace DowningInterviewProject.WebAPI.Extensions
{
    public static class CompanyDtoToModel
    {
        public static CompanyModel ToModel(this CompanyDto company)
        {
            return new CompanyModel
            {
                Name = company.Name,
                Code = company.Code,
                SharePrice = company.SharePrice,
                CreatedDate = company.CreatedDate
            };
        }
    }
}