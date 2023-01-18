namespace Alchemy.Notify.Api.Client.Models.Notify;

public class EventModel
{
	public string? Network { get; set; }
	public IEnumerable<ActivityModel>? Activity { get; set; }
}
