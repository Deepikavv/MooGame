using System;
using System.IO;
using System.Collections.Generic;
using MooGame.ClientLayer;
using System.Collections;
using Microsoft.Extensions.Hosting;
using MooGame.Interfaces;
using MooGame.GameFactory;
using MooGame.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MooGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IHost host = ConfigureDependencies(args);
            var serviceProvider = GetServiceProvider(host);

            ClientManager.StartGame(serviceProvider);

        }
        static IHost ConfigureDependencies(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                services.AddScoped<IMooGameFactory, MooGameFactory>()
                .AddTransient<EasyMooGame>()
                .AddTransient<DifficultMooGame>()
                .AddTransient<GameManager>()
                .AddTransient<GameServiceResolver>(serviceProvider => userInput =>
                {
                    if (userInput == "1")
                    {
                        return serviceProvider.GetService<EasyMooGame>()!;
                    }
                    else if (userInput == "2")
                    {
                        return serviceProvider.GetService<DifficultMooGame>()!;
                    }
                    else
                    {
                        throw new Exception("Invalid input");
                    }
                })
                ).Build();
            return host;
        }
        static IServiceProvider GetServiceProvider(IHost host)
        {
            var services = host.Services;
            var serviceScope = services.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;
            return serviceProvider;
        }
    }  
}