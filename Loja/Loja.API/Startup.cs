using Loja.API.Configurations;
using Loja.API.Services;
using Loja.Application.AssembleOrder;
using Loja.Application.AutoMapper;
using Loja.Application.Interfaces;
using Loja.Application.Services;
using Loja.Application.ViewModels;
using Loja.Application.ViewModelValidation;
using Loja.Domain.Interfaces;
using Loja.Domain.Validations;
using Loja.Infra.Context;
using Loja.Infra.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.API
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
            services.AddControllers();
            services.AddConfiguracaoToken(Configuration);
            services.AddConfiguracaoSwagger();

            services.AddDatabaseConfiguration(Configuration);
            services.AddScoped<LojaContexto>();
            services.AddScoped<ServicoToken>();
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerSetup();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
