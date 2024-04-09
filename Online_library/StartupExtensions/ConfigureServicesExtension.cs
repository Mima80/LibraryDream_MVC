using Entities;
using Entities.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using RepositoryContracts;
using ServiceContracts;
using Services;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System;

namespace LibraryDream.StartupExtensions
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProgramDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("Default"), new MySqlServerVersion(new Version(8, 0, 33))));
            services.AddControllersWithViews(options => 
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookCheckoutRepository, BookCheckoutRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookCheckoutService, BookCheckoutService>();
            services.AddScoped<IValidator<BookCheckout>, BookCheckoutValidator>();
            services.AddScoped<IValidator<Book>, BookValidator>();


            //Enable Identity in this project
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequiredLength = 5;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredUniqueChars = 3; //Eg: AB12AB (unique characters are A,B,1,2)
                })
                .AddEntityFrameworkStores<ProgramDbContext>()

                .AddDefaultTokenProviders()

                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ProgramDbContext, int>>()

                .AddRoleStore<RoleStore<ApplicationRole, ProgramDbContext, int>>();


            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); //enforces authoriation policy (user must be authenticated) for all the action methods

                options.AddPolicy("NotAuthorized", policy =>
                {
                    policy.RequireAssertion(context => !context.User.Identity.IsAuthenticated);
                });
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });

            return services;
        }
    }
}
