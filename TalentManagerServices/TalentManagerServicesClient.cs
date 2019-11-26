using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace TalentManagerServices
{
    public class TalentManagerServicesClient : HttpClient, ITalentManagerServicesClient
    {
        private readonly string TalentManagerServicesSubscriptionKey;
        private readonly string TalentManagerApiKey;
        public string TalentManagerServicesBaseUrl { get; private set; }

        public TalentManagerServicesClient(IConfiguration config)
        {
            TalentManagerServicesBaseUrl = config["TalentManagerServices:BaseUri"];
            TalentManagerServicesSubscriptionKey = config["TalentManagerServices:SubscriptionKey"];
            TalentManagerApiKey = config["TalentManagerServices:ApiKey"];

            DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", TalentManagerServicesSubscriptionKey);
            DefaultRequestHeaders.Add("ApiKey", TalentManagerApiKey);
        }

        //TODO Fix for plural employes
        public async Task<string> GetEmployees(string customerId)
        {
            DefaultRequestHeaders.Remove("CustomerId");
            DefaultRequestHeaders.Add("CustomerId", customerId);
            var uri = $"{TalentManagerServicesBaseUrl}/Employee";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetDepartment(string customerId)
        {
            DefaultRequestHeaders.Remove("CustomerId");
            DefaultRequestHeaders.Add("CustomerId", customerId);
            var uri = $"{TalentManagerServicesBaseUrl}/department";

            var response = await GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
