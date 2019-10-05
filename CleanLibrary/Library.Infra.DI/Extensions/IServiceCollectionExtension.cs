using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Livraria.Infra.Data.Context;
using Livraria.Infra.Data.Repository;
using Library.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infra.DI.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddTransient<IServiceBase<Book>, ServiceBase<Book>>();
            services.AddTransient<IServiceBase<Autor>, ServiceBase<Autor>>();
            services.AddTransient<IServiceBase<Editor>, ServiceBase<Editor>>();
            services.AddTransient<IRepositoryBase<Book>, RepositoryBase<Book>>();
            services.AddTransient<IRepositoryBase<Autor>, RepositoryBase<Autor>>();
            services.AddTransient<IRepositoryBase<Editor>, RepositoryBase<Editor>>();

            return services;
        }

        public static IServiceCollection AddServiceInfra(this IServiceCollection services)
        {
            services.AddScoped<LivrariaDbContext>();

            return services;
        }
    }
}
