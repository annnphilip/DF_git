using Abp.Authorization;
using Discussion_forum.Authorization.Roles;
using Discussion_forum.Authorization.Users;

namespace Discussion_forum.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
