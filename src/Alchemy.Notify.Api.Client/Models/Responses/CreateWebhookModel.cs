using Alchemy.Notify.Api.Client.Interfaces;

namespace Alchemy.Notify.Api.Client.Models.Responses;

public class CreateWebhookModel : IBaseResponseModel
{
	public WebhookModel? Data { get; set; }
}
