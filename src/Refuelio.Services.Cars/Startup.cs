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
using Refuelio.Common.Mongo;
using Refuelio.Common.RabbitMq;
using Refuelio.Services.Cars.Domain.Repositories;
using Refuelio.Services.Cars.Handlers;
using Refuelio.Services.Cars.Repositories;

namespace Refuelio.Services.Cars
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
            services.AddScoped<ICommandHandler<CreateCar>, CreateCarHandler>();
            services.AddScoped<ICarRepository, CarRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRabbitMq()
                .SubscribeCommand<CreateCar>();
            app.UseMvc();
        }
    }
}
