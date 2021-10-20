using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubApi.Core.Entities;
using GitHubApi.Core.IRepositories;
using GitHubApi.Infrastructure.Data;
using GitHubApi.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace GitHubApi.Infrastructure.Repositories
{
    public class RepoRepository : Repository<Repo>, IRepoRepository
    {
        public RepoRepository(GitHubApiContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Repo>> GetByUserId(int userId)
        {
            return await _dbContext.Repos
                         .Where(r => r.UserId == userId).ToListAsync();
        }
    }
}
