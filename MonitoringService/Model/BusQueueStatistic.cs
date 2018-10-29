using System;

namespace MonitoringService.Model
{
    public class BusQueueStatistic
    {
	    public Guid Id { get; set; }
	    public MessageType MessageType { get; set; }
	    public DateTime DateTime { get; set; }
	    public int ObjectCount { get; set; }
    }
}
