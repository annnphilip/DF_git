using System.Threading.Tasks;
using Abp.Application.Services;
using Discussion_forum.Sessions.Dto;

namespace Discussion_forum.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
