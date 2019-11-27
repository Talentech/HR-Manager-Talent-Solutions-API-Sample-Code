using System;
using TalentRecruiterJobPortal;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TalentRecruiterJobPortalTestClient
{
    class Program
    {
        private static ServiceProvider ServiceProvider;


        static void Main(string[] args)
        {
            SetupDI();

            string customerId = "";

            var client = ServiceProvider.GetService<ITalentRecruiterJobPortalClient>();

            var v = client.RetrieveAll(customerId);

            Console.WriteLine(v.Result);
            Console.ReadLine();
        }

        private static void SetupDI()
        {
            var collection = new ServiceCollection();

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

            collection.AddSingleton<IConfiguration>(config);

            collection.AddScoped<ITalentRecruiterJobPortalClient, TalentRecruiterJobPortalClient>();

            ServiceProvider = collection.BuildServiceProvider();

        }
    }
}
