namespace Alchemy.Notify.Api.Client.Models.Notify;

public class NotifyModel
{
	public string? WebhookId { get; set; }
	public string? Id { get; set; }
	public DateTimeOffset? CreatedAt { get; set; }
	public string? Type { get; set; }
	public EventModel? Event { get; set; }
}
