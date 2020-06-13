using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.Fundametals.Security.Data.Context;
using NetCore.Fundametals.Security.Data.Repositories;

namespace NetCore.Fundametals.Security.Client.Web
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
            //services.AddControllersWithViews();

            services.AddControllersWithViews(o=>o.Filters.Add(new AuthorizeFilter()));
            services.AddRazorPages().AddMvcOptions(o => o.Filters.Add(new AuthorizeFilter())); //filtro global

            services.AddScoped<IConferenceRepository, ConferenceRepository>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<IAttendeeRepository, AttendeeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<NetcoreFundametalsSecurityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NetCoreFundamentalsSecurityConnection")));

            //Sin autenticacion solo cookies
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie();
            //.AddCookie(o => o.LoginPath = "account/signin"); --personalizacion de login

            /*
            //Con autenticacion Google
            services.AddAuthentication(o => {
                o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; // comentar cuando se implemeta el 
                o.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
               .AddCookie()
               .AddGoogle(o =>
                 {
                     o.ClientId = Configuration["Google:ClientId"];
                     o.ClientSecret = Configuration["Google:ClientSecret"];
                 });
            */
            //Google como metodo externo de autenticacion
            services.AddAuthentication(o =>
            {
                o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
               .AddCookie()
               .AddCookie(ExternalAuthenticationDefaults.AuthenticationScheme)
               .AddGoogle(o =>
               {
                   o.SignInScheme = ExternalAuthenticationDefaults.AuthenticationScheme;
                   o.ClientId = Configuration["Google:ClientId"];
                   o.ClientSecret = Configuration["Google:ClientSecret"];
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Conference}/{action=Index}/{id?}");
            });
        }
    }
}
