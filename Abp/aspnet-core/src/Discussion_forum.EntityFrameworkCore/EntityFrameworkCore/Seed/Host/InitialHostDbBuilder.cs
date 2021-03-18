namespace Discussion_forum.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly Discussion_forumDbContext _context;

        public InitialHostDbBuilder(Discussion_forumDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
