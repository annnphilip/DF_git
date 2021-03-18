using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Discussion_forum.Configuration;

namespace Discussion_forum.Web.Host.Startup
{
    [DependsOn(
       typeof(Discussion_forumWebCoreModule))]
    public class Discussion_forumWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public Discussion_forumWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Discussion_forumWebHostModule).GetAssembly());
        }
    }
}
