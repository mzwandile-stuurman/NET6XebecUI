using Blazored.Localisation;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XebecPortal.UI.Interfaces;
using XebecPortal.UI.Services;
using XebecPortal.UI.Services.Models;
using XebecPortal.UI.Utils;
using Smart.Blazor;  

namespace XebecPortal.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddSingleton<State>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            builder.Services.AddScoped<IApplicantDataService, ApplicantDataService>();
            builder.Services.AddScoped<IApplicationDataService, ApplicationDataService>();
            builder.Services.AddScoped<IJobDataService, JobDataService>();
            builder.Services.AddScoped<IApplicationPhaseHelperDataService, ApplicationPhaseHelperDataService>();
            //Testing
            builder.Services.AddScoped<IMyJobListDataService, MyJobListDataService>();

            builder.Services.AddSmart();


            await builder.Build().RunAsync();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalisation(); // This adds the IBrowserDateTimeProvider to the DI container
        }
    }
}
