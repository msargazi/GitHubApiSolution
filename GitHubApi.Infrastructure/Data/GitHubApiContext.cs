using Microsoft.EntityFrameworkCore;

namespace GitHubApi.Infrastructure.Data
{
    public class GitHubApiContext : DbContext
    {
        public GitHubApiContext(DbContextOptions<GitHubApiContext> options) : base(options)
        {
        }
    }
}
