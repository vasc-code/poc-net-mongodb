﻿using Application.Boundaries.Cliente.PostCliente;
using Application.Commands.Cliente;
using Application.Handlers.Cliente;
using Application.Queries.Cliente.Interface;
using Application.Queries.Mongo;
using Application.UseCase.Cliente;
using Application.UseCase.Cliente.Interface;
using Domain.Services.Cliente;
using Domain.Services.Cliente.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrap
{
    internal static class ApplicationSetup
    {
        internal static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<PostClienteCommand, PostClienteOutput>, PostClienteHandler>();

            services.AddScoped<IClienteUseCase, ClienteUseCase>();

            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<IClienteQuery, ClienteQuery>();
        }
    }
}