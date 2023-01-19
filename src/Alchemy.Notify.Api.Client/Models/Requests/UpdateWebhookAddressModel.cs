using System.Text.Json.Serialization;

namespace Alchemy.Notify.Api.Client.Models.Requests;

public class UpdateWebhookAddressModel : BaseWebhookIdRequestModel
{
	[JsonPropertyName("addresses_to_add")]
	public IEnumerable<string> AddressesToAdd { get; set; } = new List<string>();

	[JsonPropertyName("addresses_to_remove")]
	public IEnumerable<string> AddressesToRemove { get; set; } = new List<string>();
}
