using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_Demo.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EF_Core_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DatabaseContext>();
                var logger = services.GetRequiredService<ILogger<Program>>();

                //Check that db is up and running
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "... Database could not be created ...");
                }


                //Check that we have some data to work with
                try
                {
                    DataInitializer.Init(context);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "... Seeding the database failed ...");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
