using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Sistema.Gestao.Application;
using Sistema.Gestao.Application.Interface;
using Sistema.Gestao.Domain.Interfaces.Repositories;
using Sistema.Gestao.Domain.Interfaces.Services;
using Sistema.Gestao.Domain.Services;
using Sistema.Gestao.Infra.Data.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Sistema.Gestao.API.Extensoes
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigurarInjecaoDependencias(this IServiceCollection services)
        {
            services.AddTransient<IEmpresaAppService, EmpresaAppService>();
            services.AddTransient<IEmpresaService, EmpresaService>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();

            services.AddTransient<IFuncionarioAppService, FuncionarioAppService>();
            services.AddTransient<IFuncionarioService, FuncionarioService>();
            services.AddTransient<IFuncionarioRepository, Funcionarioepository>();
        }

        public static IServiceCollection AdicionarDocumentacaoSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Sistema.Gestão API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Autorização JWT usando o esquema Bearer. Exemplo: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
            });
            return services;
        }
    }
}
