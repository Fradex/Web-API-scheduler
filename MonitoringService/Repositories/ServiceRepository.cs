using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonitoringService.Context;
using MonitoringService.Model;
using MonitoringService.Repositories.Interfaces;

namespace MonitoringService.Repositories
{
	public class ServiceRepository : IServiceRepository
	{
		private string ConnString => Configuration.GetSection("AppConfiguration")["connectionString"];
		public IConfiguration Configuration { get; set; }
		private IServiceProvider ServiceProvider;

		public ServiceRepository(IConfiguration configuration, IServiceProvider serviceProvider)
		{
			Configuration = configuration;
			ServiceProvider = serviceProvider;
		}

		public async Task<IEnumerable<DateStatisticDto>> GetErrorStatisticAsync()
		{
			using (var connection = new SqlConnection(ConnString))
			{
				await connection.OpenAsync();
				var sql = @"IF OBJECT_ID('#temp', 'U') IS NOT NULL
						 DROP TABLE #temp;
					select count(l.SessionId) count , cast(l.Date as date) date 
						into #temp 
						from SessionLog l with (NOLOCK) group by cast(l.Date as date)
						order by date;

					WITH n AS 
					(
					  SELECT TOP (DATEDIFF(DAY, '20180101', getdate()) + 1) 
					    n = ROW_NUMBER() OVER (ORDER BY [object_id])
					  FROM sys.all_objects
					)
					select coalesce(max(l.count),0) as ErrorCount, DATEADD(DAY, n-1, '20180101') as Date
					FROM n left join #temp l on DATEADD(DAY, n-1, '20180101') = cast(l.Date as date)
									          group by DATEADD(DAY, n-1, '20180101')
									          order by date;";

				return await connection.QueryAsync<DateStatisticDto>(sql);
			}
		}

		public async Task<IEnumerable<DateStatisticDto>> GetGenericSqlErrorStatisticAsync()
		{
			using (var connection = new SqlConnection(ConnString))
			{
				await connection.OpenAsync();
				var sql = "select count(*) as ErrorCount, cast(Date as date) as Date " +
				          "from SessionLog " +
				          "where Message like '%generic sql%'" +
				          "group by cast(Date as date) " +
				          "order by date";

				return await connection.QueryAsync<DateStatisticDto>(sql);
			}
		}


		public IEnumerable<BusStatisticByMessage> GetBusQueueStatistic()
		{
			var resultList = new List<BusStatisticByMessage>();
			using (var context = ServiceProvider.GetService<StatisticContext>())
			{
				var messageTypes = context.BusQueueStatistics
					.Where(x => x.ObjectCount > 0)
					.Select(x => x.MessageType)
					.Distinct()
					.ToList();
				foreach (var messageType in messageTypes)
				{
					var list = context.BusQueueStatistics.Where(x => x.MessageType.Id == messageType.Id).ToList();

					var busStatisticByMessage = new BusStatisticByMessage
					{
						MessageName = messageType.MessageName,
						Array = new List<dynamic[]>()
					};
					foreach (var item in list)
					{
						busStatisticByMessage.Array.Add(new dynamic[]
							{item.DateTime, item.ObjectCount});
					}

					resultList.Add(busStatisticByMessage);
				}
			}

			return resultList;
		}
	}
}