using System.Reflection;
using Euricom.MjrCenter.RegistrationApi.BusinessComponents;
using Euricom.MjrCenter.RegistrationApi.Model;
using Euricom.MjrCenter.Shared.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace Euricom.MjrCenter.RegistrationApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add application services.

            var configuration = Program.Configuration;
            var connectionString = configuration.GetConnectionString(Constants.MjrConnectionString);

            var assembly = GetType().GetTypeInfo().Assembly;
            // Add framework services.
            services.AddSingleton(configuration);            
            services.AddAuthorization();
            services.AddScoped(assembly, t => t.Namespace.EndsWith("BusinessComponents"));
            services.AddScoped(assembly, t => t.Namespace.EndsWith("Repositories"));
            services.AddDbContext<MjrContext>(options => options.UseSqlite(connectionString));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Mjr API", Version = "v1" });

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Euricom.MjrApi.xml");
                c.IncludeXmlComments(filePath);
            });
            services.AddMvc();
        }

        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IConfigurationRoot configuration)
        {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseSwaggerUi(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mjr API v1");
            });
            InnerConfigure(app, env, loggerFactory, configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IConfigurationRoot configuration)
        {
            InnerConfigure(app, env, loggerFactory, configuration);
        }

        private void InnerConfigure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IConfigurationRoot configuration)
        {
            var authConfig = configuration.GetSection("authentication");
            var options = new OpenIdConnectOptions {
                ClientId = authConfig.GetValue<string>("clientId"),
                Authority = authConfig.GetValue<string>("authority"),
                ResponseType = "id_token",
                ResponseMode = "form_post",
                SignInScheme = "cookies",
                AutomaticAuthenticate = true
            };
            options.Scope.Add("openid");   

            loggerFactory.AddConsole(configuration.GetSection("logging"));
            loggerFactory.AddDebug();

            app.UseCookieAuthentication(new CookieAuthenticationOptions { AuthenticationScheme="cookies" });
            app.UseOpenIdConnectAuthentication(options);
            app.UseSwagger();            
            app.UseMvc();
        }        
    }
}
