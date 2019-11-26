using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TalentRecruiterServices
{
    public class TalentRecuiterServicesClient : HttpClient, ITalentRecuiterServicesClient
    {
        private readonly string TalentRecuiterServicesSubscriptionKey;
        private readonly string TalentRecuiterApiKey;
        public string TalentRecuiterServicesBaseUrl { get; private set; }

        public TalentRecuiterServicesClient(IConfiguration config)
        {
            TalentRecuiterServicesBaseUrl = config["TalentRecuiterServices:BaseUri"];
            TalentRecuiterServicesSubscriptionKey = config["TalentRecuiterServices:SubscriptionKey"];
            TalentRecuiterApiKey = config["TalentRecuiterServices:ApiKey"];

            DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", TalentRecuiterServicesSubscriptionKey);
            DefaultRequestHeaders.Add("ApiKey", TalentRecuiterApiKey);
        }

        public async Task<string> GetDepartment(string customerId)
        {
            var uri = $"{TalentRecuiterServicesBaseUrl}/Department";
            DefaultRequestHeaders.Remove("CustomerId");
            DefaultRequestHeaders.Add("CustomerId", customerId);
            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetCandidates(string customerId)
        {
            var uri = $"{TalentRecuiterServicesBaseUrl}/Candidates";
            DefaultRequestHeaders.Remove("CustomerId");
            DefaultRequestHeaders.Add("CustomerId", customerId);
            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetUsers(string customerId)
        {
            var uri = $"{TalentRecuiterServicesBaseUrl}/Users";
            DefaultRequestHeaders.Remove("CustomerId");
            DefaultRequestHeaders.Add("CustomerId", customerId);
            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetPositions(string customerId)
        {
            var uri = $"{TalentRecuiterServicesBaseUrl}/Positions";
            DefaultRequestHeaders.Remove("CustomerId");
            DefaultRequestHeaders.Add("CustomerId", customerId);
            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
