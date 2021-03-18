using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Discussion_forum.Configuration;
using Discussion_forum.Web;

namespace Discussion_forum.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class Discussion_forumDbContextFactory : IDesignTimeDbContextFactory<Discussion_forumDbContext>
    {
        public Discussion_forumDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Discussion_forumDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            Discussion_forumDbContextConfigurer.Configure(builder, configuration.GetConnectionString(Discussion_forumConsts.ConnectionStringName));

            return new Discussion_forumDbContext(builder.Options);
        }
    }
}
