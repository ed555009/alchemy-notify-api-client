using Alchemy.Notify.Api.Client.Models.Requests;
using Refit;
using ResponseModel = Alchemy.Notify.Api.Client.Models.Responses;

namespace Alchemy.Notify.Api.Client.Interfaces;

[Headers("User-Agent: Alchemy.Notify.Api.Client", "Accept: application/json", "Content-Type: application/json")]
public interface INotifyApi
{
	[Get("/team-webhooks")]
	Task<ApiResponse<ResponseModel.AllWebhooksModel>> GetAllWebhooksAsync([Header("X-Alchemy-Token")] string token);

	[Post("/create-webhook")]
	Task<ApiResponse<ResponseModel.CreateWebhookModel>> CreateWebhookAsync(
		[Header("X-Alchemy-Token")] string token,
		[Body] CreateWebhookModel payload);

	[Patch("/update-webhook-addresses")]
	Task<ApiResponse<object?>> UpdateWebhookAddressesAsync(
		[Header("X-Alchemy-Token")] string token,
		[Body] UpdateWebhookAddressModel payload);

	[Put("/update-webhook-addresses")]
	Task<ApiResponse<object?>> ReplaceWebhookAddressesAsync(
		[Header("X-Alchemy-Token")] string token,
		[Body] ReplaceWebhookAddressModel payload);

	[Put("/update-webhook")]
	Task<ApiResponse<ResponseModel.CreateWebhookModel>> UpdateWebhookStatusAsync(
		[Header("X-Alchemy-Token")] string token,
		[Body] UpdateWebhookStatusModel payload);

	[Delete("/delete-webhook?webhook_id={webhookId}")]
	Task<ApiResponse<object?>> DeleteWebhookAsync([Header("X-Alchemy-Token")] string token, string webhookId);
}
