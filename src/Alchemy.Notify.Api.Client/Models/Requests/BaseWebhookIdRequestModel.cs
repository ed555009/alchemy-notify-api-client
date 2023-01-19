using System.Text.Json.Serialization;
using Alchemy.Notify.Api.Client.Interfaces;

namespace Alchemy.Notify.Api.Client.Models.Requests;

public class BaseWebhookIdRequestModel : IBaseRequestModel
{
	[JsonPropertyName("webhook_id")]
	public string? WebhookId { get; set; }
}
