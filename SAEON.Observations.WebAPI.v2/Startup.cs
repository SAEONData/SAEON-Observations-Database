using AutoMapper;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SAEON.Core;
using SAEON.Logs;
using SAEON.Observations.Core;
using SAEON.Observations.Core.Authentication;
using SAEON.Observations.Core.Entities;
using System;

namespace SAEON.Observations.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            try
            {
                SAEONLogs.Information("Starting {Application} LogLevel: {LogLevel}", ApplicationHelper.ApplicationName, SAEONLogs.Level);
                SAEONLogs.Debug("AuthenticationServerUrl: {AuthenticationServerUrl} AuthenticationServerIntrospectionUrl: {AuthenticationServerIntrospectionUrl}",
                    Configuration["AuthenticationServerUrl"], Configuration["AuthenticationServerIntrospectionUrl"]);
            }
            catch (Exception ex)
            {
                SAEONLogs.Exception(ex, "Unable to start application");
                throw;
            }
        }

        protected IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            using (SAEONLogs.MethodCall(GetType()))
            {
                try
                {
                    //services.AddCors();
                    services.AddAutoMapper(typeof(Startup));
                    services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);
                    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                        .AddCookie();
                    services
                        .AddAuthentication()
                        .AddODP(options =>
                        {
                            options.IntrospectionUrl = Configuration[ODPAuthenticationDefaults.ConfigKeyIntrospectionUrl];
                        })
                        .AddTenant(options =>
                        {
                            options.Tenants = Configuration[TenantAuthenticationDefaults.ConfigKeyTenants];
                            options.DefaultTenant = Configuration[TenantAuthenticationDefaults.ConfigKeyDefaultTenant];
                        });
                    services
                         .AddAuthorization(options =>
                         {
                             options.AddODPPolicies();
                             options.AddTenantPolicy();
                         });

                    services.AddHttpContextAccessor();

                    services.AddHealthChecks()
                        .AddUrlGroup(new Uri(Configuration["AuthenticationServerHealthCheckUrl"]), "Authentication Server")
                        .AddUrlGroup(new Uri(Configuration["AuthenticationServerIntrospectionHealthCheckUrl"]), "Authentication Server Introspection")
                        .AddDbContextCheck<ObservationsDbContext>("ObservationsDatabase");

                    services.AddDbContext<ObservationsDbContext>();

                    services.AddSwaggerGen(options =>
                    {
                        options.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Title = "SAEON.Observations.WebAPI",
                            Version = "v1",
                            Description = "SAEON Observations Database WebAPI",
                            Contact = new OpenApiContact { Name = "Tim Parker-Nance", Email = "timpn@saeon.ac.za", Url = new Uri("http://www.saeon.ac.za") },
                            License = new OpenApiLicense { Name = "Creative Commons Attribution-ShareAlike 4.0 International License", Url = new Uri("https://creativecommons.org/licenses/by-sa/4.0/") }

                        });
                        options.IncludeXmlComments("SAEON.Observations.WebAPI.v2.xml");
                        options.SchemaFilter<SwaggerIgnoreFilter>();
                    });
                    services.AddControllersWithViews();
                }
                catch (Exception ex)
                {
                    SAEONLogs.Exception(ex, "Unable to configure services");
                    throw;
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (SAEONLogs.MethodCall(GetType()))
            {
                try
                {
                    if (env.IsDevelopment())
                    {
                        app.UseDeveloperExceptionPage();
                    }
                    else
                    {
                        app.UseExceptionHandler("/Home/Error");
                        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                        app.UseHsts();
                    }
                    app.UseHttpsRedirection();
                    app.UseStaticFiles();

                    app.UseRouting();
                    //app.UseCors();
                    app.UseAuthentication();
                    app.UseAuthorization();
                    app.UseSwagger();
                    app.UseSwaggerUI(options =>
                    {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SAEON.Observations.WebAPI");
                    });

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                        {
                            Predicate = _ => true,
                            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                        });
                        endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
                    });
                }
                catch (Exception ex)
                {
                    SAEONLogs.Exception(ex, "Unable to configure application");
                    throw;
                }
            }
        }
    }
}

