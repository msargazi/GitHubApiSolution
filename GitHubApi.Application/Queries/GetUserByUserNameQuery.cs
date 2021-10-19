using GitHubApi.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace GitHubApi.Application.Queries
{
    public class GetUserByUserNameQuery : IRequest<User>
    {
        public string UserName { get; set; }
        public GetUserByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
