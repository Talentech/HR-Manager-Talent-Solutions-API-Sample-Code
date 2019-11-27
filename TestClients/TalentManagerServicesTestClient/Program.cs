using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TalentManagerServices;

namespace TalentManagerServicesTestClient
{
    class Program
    {
        private static ServiceProvider ServiceProvider;

        static void Main(string[] args)
        {
            SetupDI();

            string customerId = "";

            var client = ServiceProvider.GetService<ITalentManagerServicesClient>();

            var v = client.GetEmployees(customerId);

            Console.WriteLine(v.Result);
            Console.ReadLine();
        }

        private static void SetupDI()
        {
            var collection = new ServiceCollection();
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

            collection.AddScoped<ITalentManagerServicesClient, TalentManagerServicesClient>();

            ServiceProvider = collection.BuildServiceProvider();

        }
    }
}
