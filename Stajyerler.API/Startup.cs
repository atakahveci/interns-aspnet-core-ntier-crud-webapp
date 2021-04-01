using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Stajyerler.View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stajyerler.API
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAuthentication()
                .AddCookie(cfg => cfg.SlidingExpiration = true)
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidIssuer = StajyerJwtTokens.Issuer,
                        ValidAudience = StajyerJwtTokens.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StajyerJwtTokens.Key))
                    };
                });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
