using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace TalentRecruiterJobPortal
{
    public class TalentRecruiterJobPortalClient : HttpClient, ITalentRecruiterJobPortalClient
    {
        public string TalentRecruiterJobPortalBaseUrl { get; private set; }

        public TalentRecruiterJobPortalClient(IConfiguration config)
        {
            TalentRecruiterJobPortalBaseUrl = config["TalentRecruiterJobPortal:BaseUri"];
        }

        public async Task<string> GetCategoryList(string customerId)
        {
            string uri = $"{TalentRecruiterJobPortalBaseUrl}/{customerId}/categorylist/";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetCustomList1(string customerId)
        {
            string uri = $"{TalentRecruiterJobPortalBaseUrl}/{customerId}/customlist1/";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetCustomList2(string customerId)
        {
            string uri = $"{TalentRecruiterJobPortalBaseUrl}/{customerId}/customlist2/";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetCustomList3(string customerId)
        {
            string uri = $"{TalentRecruiterJobPortalBaseUrl}/{customerId}/customlist3/";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetDepartmentList(string customerId)
        {
            string uri = $"{TalentRecruiterJobPortalBaseUrl}/{customerId}/departmentlist/";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetDropDownList(string customerId, string dropDownListId)
        {
            string uri = $"{TalentRecruiterJobPortalBaseUrl}/{customerId}/ddlist/{dropDownListId}/";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetLocationList(string customerId)
        {
            string uri = $"{TalentRecruiterJobPortalBaseUrl}/{customerId}/locationlist/";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetPosition(string customerId, string positionId)
        {
            string uri = $"{TalentRecruiterJobPortalBaseUrl}/{customerId}/position/{positionId}/";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetPositionList(string customerId)
        {
            string uri = $"{TalentRecruiterJobPortalBaseUrl}/{customerId}/positionlist/";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetPositionTypeList(string customerId)
        {
            string uri = $"{TalentRecruiterJobPortalBaseUrl}/{customerId}/positiontypelist/";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetProjectTypeList(string customerId)
        {
            string uri = $"{TalentRecruiterJobPortalBaseUrl}/{customerId}/projecttypelist/";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> RetrieveAll(string customerId)
        {
            string uri = $"{TalentRecruiterJobPortalBaseUrl}/{customerId}/contents/";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
