using System.Threading.Tasks;
using Auth.Models;

namespace Auth
{
    public interface IAuthClient
    {
        string AuthBaseUrl { get; }

        Task<Token> GetBearerToken();
    }
}