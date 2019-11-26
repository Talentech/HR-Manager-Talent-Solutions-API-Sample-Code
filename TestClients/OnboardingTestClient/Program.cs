using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using Onboarding;
using Auth;

namespace OnboardingTestClient
{ 
    class Program
    {
        private static ServiceProvider ServiceProvider;

        static void Main(string[] args)
        {
            SetupDI();

            var onboardingClient = ServiceProvider.GetService<IOnboardingClient>();

            var v = onboardingClient.GetProcesses();

            Console.WriteLine(v.Result);
            Console.ReadLine();

            ServiceProvider.Dispose();
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
            collection.AddScoped<IAuthClient, AuthClient>();
            collection.AddScoped<IOnboardingClient, OnboardingClient>();

            ServiceProvider = collection.BuildServiceProvider();
        }
    }
}
