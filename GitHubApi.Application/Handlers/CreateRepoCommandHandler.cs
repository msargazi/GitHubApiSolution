using GitHubApi.Application.Commands;
using GitHubApi.Core.Entities;
using GitHubApi.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubApi.Application.Handlers
{
    public class CreateRepoCommandHandler : IRequestHandler<CreateRepoCommand, Repo>
    {
        private readonly IRepoRepository _repoRepository;

        public CreateRepoCommandHandler(IRepoRepository repoRepository)
        {
            _repoRepository = repoRepository;
        }
        public async Task<Repo> Handle(CreateRepoCommand command, CancellationToken cancellationToken)
        {
            var newRepo = new Repo
            {
                Description = command.Description,
                FullName = command.FullName,
                UserId = command.UserId,
                Name = command.Name,
                NodeId = command.NodeId,
                Private = command.Private,
                RepositoryId = command.RepositoryId
            };
            return await _repoRepository.AddAsync(newRepo);
        }
    }
}
