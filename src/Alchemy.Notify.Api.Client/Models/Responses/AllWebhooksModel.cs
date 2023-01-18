using Alchemy.Notify.Api.Client.Interfaces;

namespace Alchemy.Notify.Api.Client.Models.Responses;

public class AllWebhooksModel : IBaseResponseModel
{
	public IEnumerable<WebhookModel>? Data { get; set; }
}
