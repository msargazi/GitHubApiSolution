using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Api.Settings;
using GitHubApi.Application.Handlers;
using GitHubApi.Core.IRepositories;
using GitHubApi.Core.IRepositories.Base;
using GitHubApi.Infrastructure.Data;
using GitHubApi.Infrastructure.Repositories;
using GitHubApi.Infrastructure.Repositories.Base;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<GitHubApiContext>(c =>
                  c.UseSqlServer(Configuration.GetConnectionString("OrderConnection")), ServiceLifetime.Singleton);

            services.Configure<ApiSettings>(Configuration.GetSection(nameof(ApiSettings)));
            services.AddSingleton<IApiSettings>(sp => sp.GetRequiredService<IOptions<ApiSettings>>().Value);

            services.AddHttpClient();
            services.AddMediatR(typeof(GetUserByUserNameQueryHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "GitHub API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GitHub API V1");
            });
        }
    }
}
