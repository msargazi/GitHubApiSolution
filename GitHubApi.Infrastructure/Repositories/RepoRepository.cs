using GitHubApi.Core.Entities;
using GitHubApi.Core.IRepositories;
using GitHubApi.Infrastructure.Data;
using GitHubApi.Infrastructure.Repositories.Base;

namespace GitHubApi.Infrastructure.Repositories
{
    public class RepoRepository : Repository<Repo>, IRepoRepository
    {
        public RepoRepository(GitHubApiContext dbContext) : base(dbContext)
        {
        }
    }
}
