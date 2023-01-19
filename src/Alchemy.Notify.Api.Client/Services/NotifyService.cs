using Alchemy.Notify.Api.Client.Interfaces;
using Alchemy.Notify.Api.Client.Models.Requests;
using Alchemy.Notify.Api.Client.Models.Responses;
using Refit;

namespace Alchemy.Notify.Api.Client.Services;

public class NotifyService : INotifyService
{
	private readonly INotifyApi _notifyApi;

	public NotifyService(INotifyApi notifyApi) =>
		_notifyApi = notifyApi;

	public async Task<ApiResponse<Models.Responses.CreateWebhookModel>> CreateWebhookAsync(
		Models.Requests.CreateWebhookModel data) =>
			await _notifyApi.CreateWebhookAsync(data);

	public async Task<ApiResponse<object?>> DeleteWebhookAsync(string webhookId) =>
		await _notifyApi.DeleteWebhookAsync(webhookId);

	public async Task<ApiResponse<AllWebhooksModel>> GetAllWebhooksAsync() =>
		await _notifyApi.GetAllWebhooksAsync();

	public async Task<ApiResponse<object?>> ReplaceWebhookAddressesAsync(ReplaceWebhookAddressModel data) =>
		await _notifyApi.ReplaceWebhookAddressesAsync(data);

	public async Task<ApiResponse<object?>> UpdateWebhookAddressesAsync(UpdateWebhookAddressModel data) =>
		await _notifyApi.UpdateWebhookAddressesAsync(data);
}
