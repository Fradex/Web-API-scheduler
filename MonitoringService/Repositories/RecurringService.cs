using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonitoringService.Context;
using MonitoringService.Model;
using MonitoringService.Repositories.Interfaces;

namespace MonitoringService.Repositories
{
	public class RecurringService : IRecurringService
	{
		private IServiceProvider ServiceProvider;
		private string ConnString => Configuration.GetSection("AppConfiguration")["connectionString"];
		public IConfiguration Configuration { get; set; }

		public RecurringService(IConfiguration configuration, IServiceProvider serviceProvider)
		{
			Configuration = configuration;
			ServiceProvider = serviceProvider;
		}

		public void CreateStatisticPerMinute()
		{
			List<BusQueueStatisticDto> statisticList;
			using (var connection = new SqlConnection(ConnString))
			{
				var sql = @"SELECT COUNT(1) as ObjectCount, m.MessageTypeId
				FROM[CoreBus].[dbo].[Message](nolock) m
					join MessageToAdapter mta(nolock) on mta.MessageId = m.MessageId
				where 1 = 1
				and m.AdapterId = 2
				and mta.WriteStatus in (1)
				and m.Status = 2
				group by m.MessageTypeId";

				statisticList = connection.Query<BusQueueStatisticDto>(sql).ToList();
			}

			var currentDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
				DateTime.Now.Hour, DateTime.Now.Minute, 0);

			using (var context = ServiceProvider.GetService<StatisticContext>())
			{
				var messageTypes = context.MessageTypes.ToList();

				foreach (var messageType in messageTypes)
				{
					var statisticDto = statisticList.FirstOrDefault(x => x.MessageTypeId == messageType.Id);
					context.BusQueueStatistics.Add(new BusQueueStatistic
					{
						MessageType = messageType,
						DateTime = currentDateTime,
						ObjectCount = statisticDto?.ObjectCount ?? 0
					});
				}

				context.SaveChanges();
			}
		}
	}
}