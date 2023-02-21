using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using BWE.Api.Authentication;
using BWE.Api.Dependency;
using BWE.Api.Middleware;
using BWE.Application.Dependency;
using BWE.Domain.Constant;
using BWE.Domain.DBModel;
using BWE.Domain.Mapping;
using BWE.Infrastructure.Dependency;
using BWE.Infrastructure.DBContext;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Hangfire;
using BWE.Domain.Settings;

namespace BWE.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                .AddFluentValidation(opt =>
                {
                    // Validate child properties and root collection elements
                    opt.ImplicitlyValidateChildProperties = false;
                    opt.ImplicitlyValidateRootCollectionElements = false;

                    // Automatic registration of validators in assembly
                    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

            // For Entity Framework  
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString(ConfigOptions.DbConnName),
                            options => options.EnableRetryOnFailure())
                );
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString(ConfigOptions.DbConnName)));
            services.AddHangfireServer();

            services.AddServices();
            services.AddRepositories();
            services.ApplicationServices();
            services.TokenAuthentication(Configuration);

            services.AddAutoMapper(typeof(ApplicationUserMapping).Assembly);
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    {
                        builder.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            services.AddSingleton(Configuration.GetSection(ConfigOptions.MailSettingsConfigName).Get<MailSettings>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsProduction())
            {
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHangfireDashboard();
            app.UseRouting();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}