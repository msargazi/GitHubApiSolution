using GitHubApi.Core.Entities.Base;

namespace GitHubApi.Core.Entities
{
    public class User : Entity
    {
        public string Login { get; set; }
        public int UserId { get; set; }
        public string NodeId { get; set; }
        public string AvatarUrl { get; set; }

    }
}
