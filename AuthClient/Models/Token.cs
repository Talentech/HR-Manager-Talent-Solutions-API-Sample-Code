using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Auth.Models
{
    public class Token
    {
        [JsonProperty("access_token")] public string BearerToken { get; set; }
        [JsonProperty("expires_at")] public string Expires { get; set; }
        [JsonProperty("token_type")] public string Type { get; set; }
    }
}
