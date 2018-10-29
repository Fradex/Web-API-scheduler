using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringService.Model
{
	public class BusStatisticByMessage
	{
		public string MessageName { get; set; }
		public List<dynamic[]> Array { get; set; }
	}
}