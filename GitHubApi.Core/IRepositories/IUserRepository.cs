using System.Collections.Generic;
using System.Threading.Tasks;
using GitHubApi.Core.Entities;
using GitHubApi.Core.IRepositories.Base;

namespace GitHubApi.Core.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUserName(string userName);
    }
}
