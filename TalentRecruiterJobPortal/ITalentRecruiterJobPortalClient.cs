using System.Threading.Tasks;

namespace TalentRecruiterJobPortal
{
    public interface ITalentRecruiterJobPortalClient
    {
        string TalentRecruiterJobPortalBaseUrl { get; }

        Task<string> GetCategoryList(string customerId);
        Task<string> GetCustomList1(string customerId);
        Task<string> GetCustomList2(string customerId);
        Task<string> GetCustomList3(string customerId);
        Task<string> GetDepartmentList(string customerId);
        Task<string> GetDropDownList(string customerId, string dropDownListId);
        Task<string> GetLocationList(string customerId);
        Task<string> GetPosition(string customerId, string positionId);
        Task<string> GetPositionList(string customerId);
        Task<string> GetPositionTypeList(string customerId);
        Task<string> GetProjectTypeList(string customerId);
        Task<string> RetrieveAll(string customerId);
    }
}