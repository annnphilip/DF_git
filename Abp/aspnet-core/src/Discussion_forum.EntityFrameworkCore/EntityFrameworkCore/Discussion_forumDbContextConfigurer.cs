using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Discussion_forum.EntityFrameworkCore
{
    public static class Discussion_forumDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Discussion_forumDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Discussion_forumDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
