using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Discussion_forum.Authorization
{
    public class Discussion_forumAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Questions, L("Questions"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Answers, L("Answers"), multiTenancySides: MultiTenancySides.Tenant);


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, Discussion_forumConsts.LocalizationSourceName);
        }
    }
}
