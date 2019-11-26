using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Auth.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Auth
{
    public class AuthClient : IAuthClient
    {
        public string AuthBaseUrl { get; private set; }
        private readonly string AuthSubscriptionKey;

        public AuthClient(string baseUrl, string subscriptionKey)
        {
            AuthBaseUrl = baseUrl;
            AuthSubscriptionKey = subscriptionKey;
            
        }

        public AuthClient(IConfiguration config)
        {
            AuthBaseUrl         = config["Auth:BaseUri"];
            AuthSubscriptionKey = config["Auth:SubscriptionKey"];
        }

        public async Task<Token> GetBearerToken()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AuthSubscriptionKey);

            var response = await client.PostAsync($"{AuthBaseUrl}/connect/token", null);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<Token>(content);

            return token; 
        }
    }
}
