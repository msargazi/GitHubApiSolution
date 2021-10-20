using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Infrastructure;
using Api.Models;
using Api.Settings;
using GitHubApi.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepoController : BaseHttpClientWithFactory
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly IApiSettings _settings;
        #endregion

        #region Const
        public RepoController(IMediator mediator, 
            IHttpClientFactory factory, 
            IApiSettings settings)
             : base(factory)
        {
            _mediator = mediator;
            _settings = settings;
        }
        #endregion

        #region Actions
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Repo>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> GetRepositoryByUserName(string userName)
        {
            var header = new NameValueCollection();
            header.Add("User-Agent", "GithubApi");

            var message = new HttpRequestBuilder(_settings.BaseAddress)
                         .SetPath(_settings.UserPath)
                         .AddToPath(userName)
                         .AddToPath("/repos")
                         .Headers(header)
                         .HttpMethod(HttpMethod.Get)
                         .GetHttpMessage();

            var reposModel = await SendRequest<IEnumerable<RepoModel>>(message);

            var deleteAllRepoByUserId = reposModel.First().ToDeleteAllRepoByUserModel();
            await _mediator.Send(deleteAllRepoByUserId);

            foreach (var repo in reposModel)
            {
                var createRepoCommand = repo.ToModel();
                await _mediator.Send(createRepoCommand);
            }

            return Ok(reposModel);
        }
        #endregion
    }
}