using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Discussion_forum.Authorization.Roles;
using Discussion_forum.Authorization.Users;
using Discussion_forum.MultiTenancy;
using Discussion_forum.Topic;
using Discussion_forum.Questions;
using Discussion_forum.Answer;

namespace Discussion_forum.EntityFrameworkCore
{
    public class Discussion_forumDbContext : AbpZeroDbContext<Tenant, Role, User, Discussion_forumDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public Discussion_forumDbContext(DbContextOptions<Discussion_forumDbContext> options)
            : base(options)
        {
        }
        public DbSet<TopicDetails> Topics { get; set; }
        public DbSet<QuestionDetails> Questions { get; set; }
        public DbSet<AnswerDetails> Answers { get; set; }

    }
}

