using Alchemy.Notify.Api.Client.Enums;

namespace Alchemy.Notify.Api.Client.Models.Notify;

public class EventModel
{
	public NetworkType? Network { get; set; }
	public IEnumerable<ActivityModel>? Activity { get; set; }
}
