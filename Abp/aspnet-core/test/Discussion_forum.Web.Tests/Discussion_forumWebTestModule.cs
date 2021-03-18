using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Discussion_forum.EntityFrameworkCore;
using Discussion_forum.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Discussion_forum.Web.Tests
{
    [DependsOn(
        typeof(Discussion_forumWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class Discussion_forumWebTestModule : AbpModule
    {
        public Discussion_forumWebTestModule(Discussion_forumEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Discussion_forumWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(Discussion_forumWebMvcModule).Assembly);
        }
    }
}