using System.Text.Json.Serialization;
using Alchemy.Notify.Api.Client.Enums;
using Alchemy.Notify.Api.Client.Interfaces;

namespace Alchemy.Notify.Api.Client.Models.Requests;

public class CreateWebhookModel : IBaseRequestModel
{
	public NetworkType Network { get; set; }

	[JsonPropertyName("webhook_type")]
	public WebhookType Type { get; set; }

	[JsonPropertyName("webhook_url")]
	public string? Url { get; set; }

	public IEnumerable<string>? Addresses { get; set; }
}
