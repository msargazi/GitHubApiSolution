using FakeItEasy;
using GitHubApi.Application.Commands;
using GitHubApi.Application.Handlers;
using GitHubApi.Core.Entities;
using GitHubApi.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GitHubApi.Application.Test.Commands
{
    public class CreateRepoCommandHandlerTests
    {
        private readonly IRepoRepository _repoRepository;
        private readonly CreateRepoCommandHandler _createRepoCommandHandler;
        public CreateRepoCommandHandlerTests()
        {
            _repoRepository = A.Fake<IRepoRepository>();
            _createRepoCommandHandler = new CreateRepoCommandHandler(_repoRepository);
        }

        [Fact]
        public async void Handle_ShouldReturnCreatedRepo()
        {
            A.CallTo(() => _repoRepository.AddAsync(A<Repo>._)).Returns(new Repo { FullName="Test" });

            var result = await _createRepoCommandHandler.Handle(new CreateRepoCommand(), default);

        }

        [Fact]
        public async void Handle_ShouldCallRepositoryAddAsync()
        {
            await _createRepoCommandHandler.Handle(new CreateRepoCommand(), default);

            A.CallTo(() => _repoRepository.AddAsync(A<Repo>._)).MustHaveHappenedOnceExactly();
        }
    }
}
