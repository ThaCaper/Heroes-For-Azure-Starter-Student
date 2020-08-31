﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heroes.Core.ApplicationService;
using Heroes.Core.ApplicationService.impl;
using Heroes.Core.DomainService;
using Infrastructure.SQL;
using Infrastructure.SQL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Heroes.Azure.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddCors(opt => opt.AddPolicy("AllowSpecificOrigin",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            if (Environment.IsDevelopment())
                services.AddDbContext<DatabaseContext>(
                    opt => opt.UseSqlite("Data source=heroesApp.db"));

            if (Environment.IsProduction())
                services.AddDbContext<DatabaseContext>(
                    opt => opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IHeroRepository, HeroRepository>();
            services.AddScoped<IHeroService, HeroService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var service = scope.ServiceProvider;
                    var ctx = service.GetService<DatabaseContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseDeveloperExceptionPage();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var service = scope.ServiceProvider;
                    var ctx = service.GetService<DatabaseContext>();
                    ctx.Database.EnsureCreated();
                }
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("AllowSpecificOrigin");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
