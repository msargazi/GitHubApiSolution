using Api.Models;
using GitHubApi.Application.Commands;
using GitHubApi.Core.Entities;


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

        #region Repo
        public static CreateRepoCommand ToModel(this RepoModel model)
        {
            if (model == null)
                return null;
            return new CreateRepoCommand
            {
                Description = model.Description,
                FullName = model.Full_name,
                Name = model.Name,
                NodeId = model.Node_id,
                UserId = model.Owner.Id,
                Private = model.Private,
                RepositoryId = model.Id
            };
        }
        public static DeleteAllRepoByUserId ToDeleteAllRepoByUserModel(this RepoModel model)
        {
            if (model == null)
                return null;
            return new DeleteAllRepoByUserId
            {
                UserId = model.Owner.Id
            };
        }
        #endregion
    }
}
