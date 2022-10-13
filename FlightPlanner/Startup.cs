using AutoMapper;
using FlightPlanner.Core;
using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Models;
using FlightPlanner.Data;
using FlightPlanner.Filters;
using FlightPlanner.Services;
using FlightPlanner.Services.Validators;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FlightPlanner
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlightPlanner", Version = "v1" });
            });

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthorizationHandler>("BasicAuthentication", null);
            services.AddDbContext<FlightPlannerDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("FlightPlanner2"));
            });

            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<IFlightPlannerDbContext, FlightPlannerDbContext>();
            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IDbExtendedService, DbExtendedService>();
            services.AddScoped<IEntityService<Flight>, EntityService<Flight>>();
            services.AddScoped<IEntityService<Airport>, EntityService<Airport>>();
            services.AddScoped<IValidator, AddFlightRequestValidator>();
            services.AddScoped<IValidator, AirportNameDuplicationValidator>();
            services.AddScoped<IValidator, CorrectTimeValidator>();
            services.AddScoped<IValidator, AirportFromCityValidator>();
            services.AddScoped<IValidator, AirportFromCountryValidator>();
            services.AddScoped<IValidator, AirportFromNameValidator>();
            services.AddScoped<IValidator, AirportFromValidator>();
            services.AddScoped<IValidator, AirportToCityValidator>();
            services.AddScoped<IValidator, AirportToCountryValidator>();
            services.AddScoped<IValidator, AirportToNameValidator>();
            services.AddScoped<IValidator, AirportToValidator>();
            services.AddScoped<IValidator, ArrivalTimeValidator>();
            services.AddScoped<IValidator, CarrierValidator>();
            services.AddScoped<IValidator, DepartureTimeValidator>();
            services.AddSingleton<IMapper>(AutoMapperConfig.CreateMapper());

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowCredentials()
                            .AllowAnyMethod();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlightPlanner v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader().AllowCredentials().AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
