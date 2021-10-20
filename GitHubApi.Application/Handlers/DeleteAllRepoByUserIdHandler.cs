using GitHubApi.Application.Commands;
using GitHubApi.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubApi.Application.Handlers
{
    public class DeleteAllRepoByUserIdHandler : IRequestHandler<DeleteAllRepoByUserId, bool>
    {
        private readonly IRepoRepository _repoRepository;

        public DeleteAllRepoByUserIdHandler(IRepoRepository repoRepository)
        {
            _repoRepository = repoRepository;
        }
        public async Task<bool> Handle(DeleteAllRepoByUserId command, CancellationToken cancellationToken)
        {
            var allRepo =await _repoRepository.GetByUserId(command.UserId);
            foreach (var repo in allRepo)
            {
               await _repoRepository.DeleteAsync(repo);
            }
            return true;
        }
    }
}
