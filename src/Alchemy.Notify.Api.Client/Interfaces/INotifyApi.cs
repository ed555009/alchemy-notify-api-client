using Alchemy.Notify.Api.Client.Models.Requests;
using Refit;
using ResponseModel = Alchemy.Notify.Api.Client.Models.Responses;

namespace Alchemy.Notify.Api.Client.Interfaces;

[Headers("User-Agent: Alchemy.Notify.Api.Client", "Accept: application/json", "Content-Type: application/json")]
public interface INotifyApi
{
	[Get("/team-webhooks")]
	Task<ApiResponse<ResponseModel.AllWebhooksModel>> GetAllWebhooksAsync();

	[Post("/create-webhook")]
	Task<ApiResponse<ResponseModel.CreateWebhookModel>> CreateWebhookAsync([Body] CreateWebhookModel payload);

	[Patch("/update-webhook-addresses")]
	Task<ApiResponse<object?>> UpdateWebhookAddressesAsync([Body] UpdateWebhookAddressModel payload);
}
