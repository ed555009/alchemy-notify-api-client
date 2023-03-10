using Alchemy.Notify.Api.Client.Models.Requests;
using Refit;
using ResponseModel = Alchemy.Notify.Api.Client.Models.Responses;

namespace Alchemy.Notify.Api.Client.Interfaces;

public interface INotifyService
{
	/// <summary>
	/// Get all webhooks<br/>
	/// https://docs.alchemy.com/reference/team-webhooks
	/// </summary>
	Task<ApiResponse<ResponseModel.AllWebhooksModel>> GetAllWebhooksAsync();

	/// <summary>
	/// Create webhook<br/>
	/// https://docs.alchemy.com/reference/create-webhook
	/// </summary>
	Task<ApiResponse<ResponseModel.CreateWebhookModel>> CreateWebhookAsync(CreateWebhookModel data);

	/// <summary>
	/// Update webhook status<br/>
	/// https://docs.alchemy.com/reference/update-webhook
	/// </summary>
	Task<ApiResponse<ResponseModel.CreateWebhookModel>> UpdateWebhookStatusAsync(UpdateWebhookStatusModel data);

	/// <summary>
	/// Add and remove addresses from a webhook<br/>
	/// https://docs.alchemy.com/reference/update-webhook-addresses
	/// </summary>
	Task<ApiResponse<object?>> UpdateWebhookAddressesAsync(UpdateWebhookAddressModel data);

	/// <summary>
	/// Replace webhook addresses<br/>
	/// https://docs.alchemy.com/reference/replace-webhook-addresses
	/// </summary>
	Task<ApiResponse<object?>> ReplaceWebhookAddressesAsync(ReplaceWebhookAddressModel data);

	/// <summary>
	/// Delete Webhook<br/>
	/// https://docs.alchemy.com/reference/delete-webhook
	/// </summary>
	Task<ApiResponse<object?>> DeleteWebhookAsync(string webhookId);
}
