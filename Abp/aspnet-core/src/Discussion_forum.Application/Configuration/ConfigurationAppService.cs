using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Discussion_forum.Configuration.Dto;

namespace Discussion_forum.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : Discussion_forumAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
