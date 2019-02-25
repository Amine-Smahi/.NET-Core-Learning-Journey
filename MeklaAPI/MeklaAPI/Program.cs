﻿using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MeklaAPI.Repositories;
using MeklaAPI.Services;

namespace MeklaAPI.Swagger {
    public class Program {
        public static void Main (string[] args) {
            var host = CreateWebHostBuilder (args).Build ();

            // Initializes db.
            using (var scope = host.Services.CreateScope ()) {
                var services = scope.ServiceProvider;
                try {
                    var context = services.GetRequiredService<MeklaDbContext> ();
                    var dbInitializer = services.GetRequiredService<ISeedDataService> ();
                    dbInitializer.Initialize (context).GetAwaiter ().GetResult ();
                } catch (Exception ex) {
                    var logger = services.GetRequiredService<ILogger<Program>> ();
                    logger.LogError (ex, "An error occurred while seeding the database.");
                }
            }

            host.Run ();
        }

        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ();
    }
}