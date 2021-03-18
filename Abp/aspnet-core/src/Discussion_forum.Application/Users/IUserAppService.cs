using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Discussion_forum.Roles.Dto;
using Discussion_forum.Users.Dto;

namespace Discussion_forum.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
