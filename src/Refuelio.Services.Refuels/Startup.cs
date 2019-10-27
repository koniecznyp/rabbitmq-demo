using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Refuelio.Common.Commands;
using Refuelio.Common.Events;
using Refuelio.Common.Mongo;
using Refuelio.Common.RabbitMq;
using Refuelio.Services.Refuels.Domain.Repositories;
using Refuelio.Services.Refuels.Handlers;
using Refuelio.Services.Refuels.Repositories;

namespace Refuelio.Services.Refuels
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMongoDb(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddTransient<ICommandHandler<CreateRefuel>, CreateRefuelHandler>();
            services.AddTransient<IEventHandler<CarCreated>, CarCreatedHandler>();
            services.AddScoped<IRefuelRepository, RefuelRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRabbitMq()
                .SubscribeCommand<CreateRefuel>()
                .SubscribeEvent<CarCreated>();
            app.UseMvc();
        }
    }
}
