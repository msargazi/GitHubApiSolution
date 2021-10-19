using GitHubApi.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GitHubApi.Core.Entities
{
    public class Repository : Entity
    {
        public int RepositoryId { get; set; }
        public string NodeId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool Private { get; set; }
        public string Description { get; set; } 

        #region NavigationProp
        public virtual User Owner { get; set; }
        [ForeignKey("Owner")]
        public int UserId { get; set; }
        #endregion
    }
}
