using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Discussion_forum.Authorization;

namespace Discussion_forum
{
    [DependsOn(
        typeof(Discussion_forumCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class Discussion_forumApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<Discussion_forumAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(Discussion_forumApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
