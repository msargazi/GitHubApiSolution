using Api.Controllers;
using Api.Models;
using Api.Settings;
using FakeItEasy;
using GitHubApi.Application.Commands;
using GitHubApi.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using Xunit;

namespace Api.Test.Controllers
{
    public class RepoControllerTest
    {
        #region Fields
        private readonly RepoController _repoController;
        private readonly Repo _repo;
        private readonly IMediator _mediator;
        private readonly IApiSettings _settings;
        private readonly IHttpClientFactory _factory;
        #endregion

        #region Const
        public RepoControllerTest()
        {
            _mediator = A.Fake<IMediator>();
            _settings = A.Fake<IApiSettings>();
            _factory = A.Fake<IHttpClientFactory>();
            _repoController = new RepoController(_mediator, _factory, _settings);
            _repo = new Repo
            {
                Description = "test",
                FullName = "test",
                RepositoryId = 1,
                Name = "test",
                NodeId = "1",
                Private = false
            };

            A.CallTo(() => _mediator.Send(A<CreateRepoCommand>._, A<CancellationToken>._)).Returns(_repo);
        }
        #endregion

        #region TestAction
        [Fact]
        public async void GetRepositoryByUserName_ShouldReturnListOfRepo()
        {
            var result = await _repoController.GetRepositoryByUserName("test");

            Assert.IsType<List<RepoModel>>(result);

        }
        #endregion
    }
}
