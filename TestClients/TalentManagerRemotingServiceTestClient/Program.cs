using System;
using System.IO;
using System.ServiceModel;
using Microsoft.Extensions.Configuration;
using ServiceReference1;

namespace TalentManagerRemotingServiceTestClient
{
    class Program
    {
        private IConfiguration configuration;

        static void Main(string[] args)
        {

            var config = SetUp();

            var baseUri = config.GetSection("TalentManagerRemotingService:BaseUri").Value;
            var subscriptionkey = config.GetSection("TalentManagerRemotingService:SubscriptionKey").Value;
            var authenticationToken = config.GetSection("TalentRecruiterRemotingService:AuthenticationToken").Value;

            string APISubscriptionKeyQuery = $"subscription-key={subscriptionkey}";

            var binding = new BasicHttpsBinding();

            var endpoint = new System.ServiceModel.EndpointAddress(baseUri + "?" + APISubscriptionKeyQuery);

            var talentMangerRemotingServiceClient = new TalentMangerRemotingServiceClient(binding, endpoint);

            //Example of how to fill out the request
            //Delete and replace these details with your company data

            var query = new GetBatchSyncEmployeesStatusRqt() {
                AuthenticationToken = authenticationToken,
                CustomerId = 1886,
                ReferenceToken = "20191017-4",
                InitialReferenceToken = "20191017-4"
            };

            //End of Example

            var v = talentMangerRemotingServiceClient.GetBatchSyncEmployeesStatusAsync(query); v.Wait();

            Console.WriteLine(v.Result.TransactionStatus.StatusDescription);

            Console.Read();
        }

        public static IConfiguration SetUp()
        {
            //TODO Add to enviroment settings
            //var enviroment = "Test";
            var enviroment = "Production";

            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile($"appsettings.json")
               .AddJsonFile($"appsettings.{enviroment}.json", false, true);

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{enviroment}.json", false, true)
                .Build();

            return config;
        }

    }
}
