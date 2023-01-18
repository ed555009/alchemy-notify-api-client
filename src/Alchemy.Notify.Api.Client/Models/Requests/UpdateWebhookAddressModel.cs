using System.Text.Json.Serialization;
using Alchemy.Notify.Api.Client.Interfaces;

namespace Alchemy.Notify.Api.Client.Models.Requests;

public class UpdateWebhookAddressModel : IBaseRequestModel
{
	[JsonPropertyName("webhook_id")]
	public string? WebhookId { get; set; }

	[JsonPropertyName("addresses_to_add")]
	public IEnumerable<string> AddressesToAdd { get; set; } = new List<string>();

	[JsonPropertyName("addresses_to_remove")]
	public IEnumerable<string> AddressesToRemove { get; set; } = new List<string>();
}
