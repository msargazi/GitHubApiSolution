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
using GitHubApi.Application.Queries;
using GitHubApi.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseHttpClientWithFactory
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly IApiSettings _settings;
        #endregion

        #region Const
        public UserController(IMediator mediator, IHttpClientFactory factory, IApiSettings settings)
             : base(factory)
        {
            _mediator = mediator;
            _settings = settings;
        }
        #endregion

        #region Actions
        [HttpGet]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> GetUserByUserName(string userName)
        {
            var query = new GetUserByUserNameQuery(userName);
            var user = await _mediator.Send(query);

            if (user == null)
            {
                var header = new NameValueCollection();
                header.Add("User-Agent", "GithubApi");

                var message = new HttpRequestBuilder(_settings.BaseAddress)
                             .SetPath(_settings.UserPath)
                             .AddToPath(userName)
                             .Headers(header)
                             .HttpMethod(HttpMethod.Get)
                             .GetHttpMessage();

                var userModel = await SendRequest<UserModel>(message);
                user = userModel.ToModel();
                var createUserCommand = user.ToModel();
                await _mediator.Send(createUserCommand);
            }

            return Ok(user);
        }
        #endregion

    }
}