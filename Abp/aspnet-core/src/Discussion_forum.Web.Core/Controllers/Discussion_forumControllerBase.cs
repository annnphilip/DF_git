using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Discussion_forum.Controllers
{
    public abstract class Discussion_forumControllerBase: AbpController
    {
        protected Discussion_forumControllerBase()
        {
            LocalizationSourceName = Discussion_forumConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
