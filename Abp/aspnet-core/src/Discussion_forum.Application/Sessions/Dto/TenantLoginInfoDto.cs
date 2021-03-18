using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Discussion_forum.MultiTenancy;

namespace Discussion_forum.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
