using Api.Models;
using GitHubApi.Application.Commands;
using GitHubApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure
{
    public static class ExtensionMethods
    {

        #region User
        public static User ToModel(this UserModel model)
        {
            if (model == null)
                return null;
            return new User
            {
                AvatarUrl = model.Avatar_url,
                UserId = model.Id,
                Login = model.Login,
                NodeId = model.Node_id
            };
        }
        public static CreateUserCommand ToModel(this User model)
        {
            if (model == null)
                return null;
            return new CreateUserCommand
            {
                AvatarUrl = model.AvatarUrl,
                Login = model.Login,
                NodeId = model.NodeId,
                UserId = model.UserId
            };
        }
        #endregion
    }
}
