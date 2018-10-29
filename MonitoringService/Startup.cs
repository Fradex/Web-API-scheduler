using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonitoringService.Context;
using MonitoringService.Repositories;
using MonitoringService.Repositories.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace MonitoringService
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<StatisticContext>(options =>
				options.UseSqlServer(Configuration.GetSection("AppConfiguration")["DbContext"]));
			services.AddMvc();

			// Register the Swagger generator, defining 1 or more Swagger documents
			services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}); });

			services.AddSingleton(Configuration);
			services.AddTransient<IServiceRepository, ServiceRepository>();
			services.AddTransient<IRecurringService, RecurringService>();
			services.AddHangfire(config => config.UseMemoryStorage());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
				{
					HotModuleReplacement = true
				});
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

			app.UseHangfireDashboard();
			app.UseHangfireServer();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");

				routes.MapSpaFallbackRoute(
					name: "spa-fallback",
					defaults: new {controller = "Home", action = "Index"});
			});

			var serviceProvider = app.ApplicationServices;

			RecurringJob.AddOrUpdate(
				() => serviceProvider.GetService<IRecurringService>().CreateStatisticPerMinute(),
				Cron.MinuteInterval(5));
		}
	}
}