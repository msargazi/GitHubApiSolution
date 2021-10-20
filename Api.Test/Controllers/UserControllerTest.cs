using Api.Controllers;
using Api.Models;
using Api.Settings;
using FakeItEasy;
using GitHubApi.Application.Commands;
using GitHubApi.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using Xunit;

namespace Api.Test.Controllers
{
    public class UserControllerTest
    {
        #region Fields
        private readonly UserController _userController;
        private readonly User _user;
        private readonly IMediator _mediator;
        private readonly IApiSettings _settings;
        private readonly IHttpClientFactory _factory;
        #endregion

        #region Const
        public UserControllerTest()
        {
            _mediator = A.Fake<IMediator>();
            _settings = A.Fake<IApiSettings>();
            _factory = A.Fake<IHttpClientFactory>();
            _userController = new UserController(_mediator, _factory, _settings);
            _user = new User
            {
                Login = "mohammadsargazi",
                AvatarUrl = "https://avatars.githubusercontent.com/u/56997437?v=4",
                UserId = 56997437,
                NodeId = "MDQ6VXNlcjU2OTk3NDM3"
            };

            A.CallTo(() => _mediator.Send(A<CreateUserCommand>._, A<CancellationToken>._)).Returns(_user);
        }
        #endregion

        #region TestAction
        [Fact]
        public async void GetUserByUserName_ShouldReturnUser()
        {
            var result = await _userController.GetUserByUserName(_user.Login);

            Assert.IsType<UserModel>(result);

        }
        #endregion
    }
}
