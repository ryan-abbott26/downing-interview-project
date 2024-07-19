using DowningInterviewProject.API.Dto;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace DowningInterviewProject.API.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Downing.Investment.Database;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public async Task<List<CompanyDto>> GetCompanies()
        {
            var companies = new List<CompanyDto>();

            try
            {
                using var connection = new SqlConnection(_connectionString);
                
                connection.Open();
                var sql = "select CompanyName, Code, SharePrice, CreatedDate from dbo.Companies order by CompanyName asc";

                using var command = new SqlCommand(sql, connection);
                using var reader = await command.ExecuteReaderAsync();
                        
                while (await reader.ReadAsync())
                {
                    var company = new CompanyDto
                    {
                        Name = reader.IsDBNull(reader.GetOrdinal("CompanyName")) ? string.Empty : reader.GetString(reader.GetOrdinal("CompanyName")),
                        Code = reader.IsDBNull(reader.GetOrdinal("Code")) ? string.Empty : reader.GetString(reader.GetOrdinal("Code")),
                        SharePrice = reader.IsDBNull(reader.GetOrdinal("SharePrice")) ? null : reader.GetDecimal(reader.GetOrdinal("SharePrice")),
                        CreatedDate = reader.IsDBNull(reader.GetOrdinal("CreatedDate")) ? null : reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                    };

                    companies.Add(company);
                }               

                connection.Close();
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
                using var connection = new SqlConnection(_connectionString);

                connection.Open();
                var sql = $"insert into dbo.Companies(CompanyName, Code, SharePrice, CreatedDate) " +
                          $"values('{company.Name}', '{company.Code}', {company.SharePrice ?? SqlDecimal.Null}, GETDATE())";

                using var command = new SqlCommand(sql, connection);
                var rows = await command.ExecuteNonQueryAsync();

                connection.Close();
                return rows == 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
