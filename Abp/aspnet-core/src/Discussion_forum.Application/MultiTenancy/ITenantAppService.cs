using Abp.Application.Services;
using Discussion_forum.MultiTenancy.Dto;

namespace Discussion_forum.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

