using AzureApp;
using AzureApp.Data;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly:WebJobsStartup(typeof(Startup))]
namespace AzureApp
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            string connString = Environment.GetEnvironmentVariable("AzureSqlConn");
            builder.Services.AddDbContext<AzureDbContext>(
                    options => options.UseSqlServer(connString)
                );
            builder.Services.BuildServiceProvider();
        }
    }
}
