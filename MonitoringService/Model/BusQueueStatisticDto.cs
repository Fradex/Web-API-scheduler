using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringService.Model
{
    public class BusQueueStatisticDto
    {
	    public int MessageTypeId { get; set; }
	    public DateTime DateTime { get; set; }
	    public int ObjectCount { get; set; }
	}
}
