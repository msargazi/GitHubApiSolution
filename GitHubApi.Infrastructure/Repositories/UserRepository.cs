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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(GitHubApiContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetByUserId(int userId)
        {
           return await _dbContext.Users
                         .Where(x => x.UserId == userId)
                         .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            return await _dbContext.Users
                         .Where(x => x.Login == userName)
                         .FirstOrDefaultAsync();
        }
    }
}
