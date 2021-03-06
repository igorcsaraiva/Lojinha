using AutoMapper;
using Loja.Application.AutoMapper;
using Loja.Application.Interfaces;
using Loja.Application.Services;
using Loja.Domain.Interfaces;
using Loja.Domain.Validations;
using Loja.Infra.Context;
using Loja.Infra.Repository;
using Loja.Web.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.Application.AssembleOrder;
using Loja.Application.ViewModelValidation;
using Loja.Application.ViewModels;

namespace Loja.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", true, true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddDatabaseConfiguration(Configuration);
            services.AddScoped<LojaContexto>();
            services.AddScoped<IClienteAppSevicos, ClienteAppService>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IProdutoAppServicos, ProdutoAppService>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IPedidoAppServicos, PedidoAppService>();
            services.AddScoped<IPedidosRepositorio, PedidoRepositorio>();
            services.AddScoped<IValidarCliente, ServicoValidacaoCliente>();
            services.AddScoped<IValidarProduto, ServicoValidacaoProduto>();
            services.AddScoped<IValidarPedido, ServicoValidacaoPedido>();
            services.AddScoped<IValidarView<PedidoViewModelCadastro>, ValidarPedidoViewModelCadastro>();
            services.AddScoped<IMontarPedido, PedidoViewModelCadastrarParaPedidoDomain>();
            services.AddAutoMapper(typeof(ClienteDomainParaUsuarioViewModel), typeof(UsuarioViewModelParaClienteDomain));
            services.AddAutoMapper(typeof(ProdutoDomainParaProdutoViewModel), typeof(ProdutoViewModelParaProdutoDomain));
            services.AddMvc().AddNewtonsoftJson(Op => Op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
