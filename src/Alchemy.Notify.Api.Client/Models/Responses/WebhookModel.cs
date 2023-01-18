using System.Text.Json.Serialization;
using Alchemy.Notify.Api.Client.Enums;
using Alchemy.Notify.Api.Client.Interfaces;

namespace Alchemy.Notify.Api.Client.Models.Responses;

public class WebhookModel : IBaseResponseModel
{
	public string? Id { get; set; }

	public NetworkType Network { get; set; }

	[JsonPropertyName("webhook_type")]
	public WebhookType Type { get; set; }

	[JsonPropertyName("webhook_url")]
	public string? Url { get; set; }

	[JsonPropertyName("is_active")]
	public bool IsActive { get; set; }

	[JsonPropertyName("time_created")]
	public long TimeCreated { get; set; }

	[JsonPropertyName("signing_key")]
	public string? SigningKey { get; set; }

	public string? Version { get; set; }

	public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeMilliseconds(TimeCreated);
}
