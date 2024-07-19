namespace DowningInterviewProject.API.Dto
{
    public class CompanyDto
    {
        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public decimal? SharePrice { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
