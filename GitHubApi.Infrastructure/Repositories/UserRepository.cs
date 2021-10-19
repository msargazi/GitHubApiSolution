using GitHubApi.Core.Entities;
using GitHubApi.Core.IRepositories;
using GitHubApi.Infrastructure.Data;
using GitHubApi.Infrastructure.Repositories.Base;

namespace GitHubApi.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(GitHubApiContext dbContext) : base(dbContext)
        {
        }
    }
}
