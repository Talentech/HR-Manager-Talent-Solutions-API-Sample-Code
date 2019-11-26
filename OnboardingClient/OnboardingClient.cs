using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Auth.Models;
using Auth;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;

namespace Onboarding
{
    public class OnboardingClient : HttpClient, IOnboardingClient
    {
        private Token _token;
        private IAuthClient auth;

        private readonly string OnboardingSubscriptionKey;
        public string OnboardingBaseUrl { get; private set; }

        public OnboardingClient(IAuthClient authClient, IConfiguration config)
        {
            OnboardingBaseUrl = config["Onboarding:BaseUri"];
            OnboardingSubscriptionKey = config["Onboarding:SubscriptionKey"];

            auth = authClient;
             
#if useLegacyHeaders
            //config supporting lagacy Api headers
            var t = Task.Run(() => auth.GetBearerToken()); t.Wait();
            _token = t.Result;
            var jwtToken = new JwtSecurityToken(_token.BearerToken);
            var userId = jwtToken.Subject;
            var tenantId = jwtToken.Claims.FirstOrDefault(a => a.Type == "tenantId").Value;
            DefaultRequestHeaders.Add("X-Request-UserId", userId);
            DefaultRequestHeaders.Add("X-Request-TenantId", tenantId);
#endif

            DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", OnboardingSubscriptionKey);
        }
         
        /// <summary>
        /// Example of how to access of the endpoint
        /// </summary>
        /// <returns>Onboarding processes in json format</returns>
        public async Task<string> GetProcesses()
        {
            await RefreshAccessToken();

            var uri = $"{OnboardingBaseUrl}/Processes";
            var response = await GetAsync(uri);
            response.EnsureSuccessStatusCode();

            //TODO Model and map to class objects
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        private async Task RefreshAccessToken()
        {
            if (_token is null || DateTime.Compare(DateTime.Now, DateTime.Parse(_token.Expires)) < 0 )
            {
                _token = await auth.GetBearerToken();
                DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_token.Type, _token.BearerToken);
            }
        }

    }
}
