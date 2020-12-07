using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Context;
using ClinicaVeterinaria.Dados;
using ClinicaVeterinaria.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClinicaVeterinaria
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
            services.AddScoped<BichinhoRepositorio>();
            services.AddScoped<ResponsavelRepositorio>();
            services.AddScoped<VeterinarioRepositorio>();
            services.AddScoped<AtendimentoRepositorio>();
            services.AddScoped<BanhoTosaRepositorio>();


            services.AddHttpContextAccessor();


            services.AddRazorPages()
                .AddRazorRuntimeCompilation();

            services.AddDbContext<VeterinariaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<Usuario, IdentityRole>().
                AddEntityFrameworkStores<VeterinariaContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Usuario/Login";
                options.AccessDeniedPath = "/Usuario/AcessoNegado";
            });

            services.AddSession();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<Usuario> userManager)
        {
            //https://stackoverflow.com/questions/50785009/how-to-seed-an-admin-user-in-ef-core-2-1-0
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


            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Atendimentos}/{action=ListaAtendimentos}/{id?}");
            });

            CriarUsuario(userManager);
        }

        private void CriarUsuario(UserManager<Usuario> userManager)
        {           
            
            // find the user with the admin email 
            var email = "admin@bichinhos.com";
            var _user = userManager.FindByEmailAsync(email).Result;

            // check if the user exists
            if (_user == null)
            {
                //Here you could create the super admin who will maintain the web app
                var usuario = new Usuario
                {
                    UserName = "Administrador",
                    Email = email,
                    EmailConfirmed = true
                };

                string adminPassword = "Bichinhos123@";
                var criarUsuario = userManager.CreateAsync(usuario, adminPassword).Result;
            }
        }
    }
}
