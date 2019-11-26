using System.Threading.Tasks;

namespace TalentRecruiterServices
{
    public interface ITalentRecuiterServicesClient
    {
        string TalentRecuiterServicesBaseUrl { get; }

        Task<string> GetCandidates(string customerId);
        Task<string> GetDepartment(string customerId);
        Task<string> GetPositions(string customerId);
        Task<string> GetUsers(string customerId);
    }
}