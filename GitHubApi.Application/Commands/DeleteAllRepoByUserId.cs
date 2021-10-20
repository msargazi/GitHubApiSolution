using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubApi.Application.Commands
{
    public class DeleteAllRepoByUserId : IRequest<bool>
    {
        public int UserId { get; set; }
        
    }
}
