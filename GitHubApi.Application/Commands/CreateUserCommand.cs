using GitHubApi.Core.Entities;
using MediatR;

namespace GitHubApi.Application.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Login { get; set; }
        public int UserId { get; set; }
        public string NodeId { get; set; }
        public string AvatarUrl { get; set; }
    }
}
