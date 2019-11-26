using System.Threading.Tasks;

namespace Onboarding
{
    public interface IOnboardingClient
    {
        string OnboardingBaseUrl { get; }

        Task<string> GetProcesses();
    }
}