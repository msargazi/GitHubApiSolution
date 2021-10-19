using GitHubApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitHubApi.Infrastructure.Data
{
    public class GitHubApiContext : DbContext
    {
        public GitHubApiContext(DbContextOptions<GitHubApiContext> options) : base(options)
        {
        }

        #region DbSets
        public DbSet<Repo> Repos { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion
    }
}
