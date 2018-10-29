using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MonitoringService.Model;
using MonitoringService.Repositories.Interfaces;

namespace MonitoringService.Controllers
{
	[Route("api/[controller]")]
	public class ServiceController : Controller
	{
		private IServiceProvider ServiceProvider;

		public ServiceController(IServiceProvider serviceProvider)
		{
			ServiceProvider = serviceProvider;
		}

		[HttpGet("[action]")]
		public async Task<IEnumerable<DateStatisticDto>> GetStatistics()
		{
			var repo = ServiceProvider.GetService<IServiceRepository>();
			return await repo.GetErrorStatisticAsync();
		}

		[HttpGet("[action]")]
		public async Task<IEnumerable<DateStatisticDto>> GetGenericSqlErrorStatistics()
		{
			var repo = ServiceProvider.GetService<IServiceRepository>();
			return await repo.GetGenericSqlErrorStatisticAsync();
		}

		[HttpGet("[action]")]
		public IEnumerable<BusStatisticByMessage> GetBusQueueStatistic()
		{
			var repo = ServiceProvider.GetService<IServiceRepository>();
			return repo.GetBusQueueStatistic();
		}
	}
}