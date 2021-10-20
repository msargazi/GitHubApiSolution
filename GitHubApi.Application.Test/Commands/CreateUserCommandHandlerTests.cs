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
    public class CreateUserCommandHandlerTests
    {
        private readonly IUserRepository _userRepository;
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        public CreateUserCommandHandlerTests()
        {
            _userRepository = A.Fake<IUserRepository>();
            _createUserCommandHandler = new CreateUserCommandHandler(_userRepository);
        }

        [Fact]
        public async void Handle_ShouldReturnCreatedUser()
        {
            A.CallTo(() => _userRepository.AddAsync(A<User>._)).Returns(new User { Login = "Test" });

            var result = await _createUserCommandHandler.Handle(new CreateUserCommand(), default);

        }

        [Fact]
        public async void Handle_ShouldCallRepositoryAddAsync()
        {
            await _createUserCommandHandler.Handle(new CreateUserCommand(), default);

            A.CallTo(() => _userRepository.AddAsync(A<User>._)).MustHaveHappenedOnceExactly();
        }
    }
}
