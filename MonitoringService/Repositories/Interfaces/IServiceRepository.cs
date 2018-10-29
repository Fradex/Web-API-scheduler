using System.Collections.Generic;
using System.Threading.Tasks;
using MonitoringService.Model;

namespace MonitoringService.Repositories.Interfaces
{
    interface IServiceRepository
    {
	    Task<IEnumerable<DateStatisticDto>> GetErrorStatisticAsync();
	    Task<IEnumerable<DateStatisticDto>> GetGenericSqlErrorStatisticAsync();
	    IEnumerable<BusStatisticByMessage> GetBusQueueStatistic();
    }
}
