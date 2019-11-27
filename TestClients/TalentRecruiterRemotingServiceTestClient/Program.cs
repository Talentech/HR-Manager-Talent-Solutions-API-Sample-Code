using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.Extensions.Configuration;
using ServiceReference1;

namespace TalentRecruiterRemotingServiceTestClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = SetUp();
           
            var baseUri         = config.GetSection("TalentRecruiterRemotingService:BaseUri").Value;
            var subscriptionkey = config.GetSection("TalentRecruiterRemotingService:SubscriptionKey").Value;
            var authenticationToken = config.GetSection("TalentRecruiterRemotingService:AuthenticationToken").Value;

            string APISubscriptionKeyQuery = $"subscription-key={subscriptionkey}";
            
            var binding = new BasicHttpsBinding();

            var endpoint = new System.ServiceModel.EndpointAddress(baseUri + "?" + APISubscriptionKeyQuery);

            var client = new TalentRecruiterRemotingServiceClient(binding, endpoint);
            
            //Example of how to fill out the request
            //Delete and replace these details with your company data

            var query = new BatchSyncDepartmentsRqt
            {
                AuthenticationToken = authenticationToken,
                CustomerId = 1885,
                DepartmentId = new RemotableIdOfint { Id = 18960 },
                IncludeDebugOverview = true,
                ReferenceToken = "20191029-2",
          
                DepartmentList = new Department[]
                {
                    new Department
                    {
                        Id = new RemotableIdOfint(){Id = 18961},
                        ParentDepartmentId = new RemotableIdOfint(){Id =18956},
                        Title = "APISyncTest 20191029-2",
                        Details = new DepartmentDetails()
                        {
                            CreatedDateTimeUtc = DateTime.Parse("0001-01-01T00:00:00"),
                            UpdatedDateTimeUtc = DateTime.Parse("0001-01-01T00:00:00"),
                            Address = new Address
                            {
                                AddressLine1 = "TestStreet 20191029-2",
                                AddressLine2 = "20191029-2",
                                City = "Cph 20191029-2",
                                Country = "DK 20191029-2",
                                ZipCode = "\"20191029-2\""
                            },
                            InternalName = "IntName 20191029-2 2",
                            IsDeletable = true,
                            IsProjectCreationAllowed = true,
                            IsRoot = false,
                            IsSynchronized = false,
                            IsVirtualRoot = false,
                            SiblingSortOrder = 0
                        }
                    },
                   
                },
                DepartmentUpdateBypassTypes = DepartmentUpdateBypassTypes.None,
                DoNotDeleteUnlistedSynchronizedDepartments = true,
                DoNotDeleteUsersInDeletedDepartments = false,
                DoNotUnpublishAndDeactivateProjectsInDeletedDepartments = true
            };

            //End of Example

            var v = client.BatchSyncDepartmentsAsync(query); v.Wait();

            Console.WriteLine(v.Result.ReferenceToken);

            Console.ReadLine();
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
