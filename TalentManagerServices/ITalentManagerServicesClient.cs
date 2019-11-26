using System.Threading.Tasks;

namespace TalentManagerServices
{
    public interface ITalentManagerServicesClient
    {
        string TalentManagerServicesBaseUrl { get; }

        Task<string> GetDepartment(string customerId);
        Task<string> GetEmployees(string customerId);
    }
}