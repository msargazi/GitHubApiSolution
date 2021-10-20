using GitHubApi.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace GitHubApi.Application.Commands
{
    public class CreateRepoCommand : IRequest<Repo>
    {
        public int RepositoryId { get; set; }
        public string NodeId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool Private { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
