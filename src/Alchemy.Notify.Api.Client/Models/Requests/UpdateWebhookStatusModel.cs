using System.Text.Json.Serialization;

namespace Alchemy.Notify.Api.Client.Models.Requests;

public class UpdateWebhookStatusModel : BaseWebhookIdRequestModel
{
	[JsonPropertyName("is_active")]
	public bool IsActive { get; set; } = true;
}
