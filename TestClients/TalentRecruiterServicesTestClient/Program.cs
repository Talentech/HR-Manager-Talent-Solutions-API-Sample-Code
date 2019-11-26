using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Web;
using TalentRecruiterServices;
using System.IO;

namespace TalentRecruiterServicesTestClient
{
    class Program
    {
        private static ServiceProvider ServiceProvider;

        static void Main(string[] args)
        {
            SetupDI();

            string customerId = "";

            var client = ServiceProvider.GetService<ITalentRecuiterServicesClient>();

            var v = client.GetUsers(customerId);

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

            collection.AddScoped<ITalentRecuiterServicesClient, TalentRecuiterServicesClient>();

            ServiceProvider = collection.BuildServiceProvider();

        }
    }
}
