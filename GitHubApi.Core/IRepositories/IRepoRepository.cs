using GitHubApi.Core.Entities;
using GitHubApi.Core.IRepositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubApi.Core.IRepositories
{
    public interface IRepoRepository : IRepository<Repo>
    {
        Task<IEnumerable<Repo>> GetByUserId(int userId);
    }
}
