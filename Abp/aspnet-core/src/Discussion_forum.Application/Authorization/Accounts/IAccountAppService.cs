using System.Threading.Tasks;
using Abp.Application.Services;
using Discussion_forum.Authorization.Accounts.Dto;

namespace Discussion_forum.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
