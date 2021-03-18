using System.Threading.Tasks;
using Discussion_forum.Configuration.Dto;

namespace Discussion_forum.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
