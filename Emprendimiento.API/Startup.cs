using System;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Emprendimiento.API.Repositories;
using Emprendimiento.API.Services;
using Emprendimiento.API.Services.Auth;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Emprendimiento.API.Services.Recurring;

namespace Emprendimiento.API
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAny",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            //para generar el token (rompe sin esto) 
            IdentityModelEventSource.ShowPII = true;

            //validar request desde controller
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = false,
                        SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                        {
                            var jwt = new JwtSecurityToken(token);

                            return jwt;
                        },
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                    };
                });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Control Center",
                    Description = "API control de productos",
                    Contact = new OpenApiContact
                    {
                        Name = "Emiliano Elicegui",
                        Email = "emielicegui@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/eliceguiemiliano/")
                    },
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }   
                });

            });

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IRepositoryAuth, RepositoryAuth>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IRepositoryGeneric, RepositoryGeneric>();
            services.AddScoped<IGenericService, GenericService>();

            services.AddScoped<IRepositoryCompany, RepositoryCompany>();
            services.AddScoped<ICompanyService, CompanyService>();
            
            services.AddScoped<IRepositoryProduct, RepositoryProduct>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IRepositoryProvider, RepositoryProvider>();
            services.AddScoped<IProviderService, ProviderService>();

            services.AddScoped<IRepositorySpending, RepositorySpending>();
            services.AddScoped<ISpendingService, SpendingService>();

            services.AddScoped<IRepositoryClient, RepositoryClient>();
            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<IRecurringService, RecurringService>();
            services.AddScoped<IRepositoryRecurring, RepositoryRecurring>();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Unspecified;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });

        }
    }
}
