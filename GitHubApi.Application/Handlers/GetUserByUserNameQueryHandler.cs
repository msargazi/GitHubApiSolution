using GitHubApi.Application.Queries;
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
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByUserNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByUserName(request.UserName);
        }
    }
}
