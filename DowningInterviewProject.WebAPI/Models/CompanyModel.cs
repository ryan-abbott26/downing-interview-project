namespace DowningInterviewProject.WebAPI.Models
{
    public class CompanyModel
    {
        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public decimal? SharePrice { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
