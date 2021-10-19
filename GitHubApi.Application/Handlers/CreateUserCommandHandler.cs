using GitHubApi.Application.Commands;
using GitHubApi.Core.Entities;
using GitHubApi.Core.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubApi.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                AvatarUrl = command.AvatarUrl,
                Login = command.Login,
                NodeId = command.NodeId,
                UserId = command.UserId
            };
            return await _userRepository.AddAsync(newUser);
        }
    }
}
