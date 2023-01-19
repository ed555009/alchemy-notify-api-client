using Alchemy.Notify.Api.Client.Interfaces;
using Alchemy.Notify.Api.Client.Models.Requests;
using Refit;
using ResponseModel = Alchemy.Notify.Api.Client.Models.Responses;

namespace Alchemy.Notify.Api.Client.Services;

public class NotifyService : INotifyService
{
	private readonly INotifyApi _notifyApi;

	public NotifyService(INotifyApi notifyApi) =>
		_notifyApi = notifyApi;

	public async Task<ApiResponse<ResponseModel.CreateWebhookModel>> CreateWebhookAsync(CreateWebhookModel data) =>
			await _notifyApi.CreateWebhookAsync(data);

	public async Task<ApiResponse<object?>> DeleteWebhookAsync(string webhookId) =>
		await _notifyApi.DeleteWebhookAsync(webhookId);

	public async Task<ApiResponse<ResponseModel.AllWebhooksModel>> GetAllWebhooksAsync() =>
		await _notifyApi.GetAllWebhooksAsync();

	public async Task<ApiResponse<object?>> ReplaceWebhookAddressesAsync(ReplaceWebhookAddressModel data) =>
		await _notifyApi.ReplaceWebhookAddressesAsync(data);

	public async Task<ApiResponse<object?>> UpdateWebhookAddressesAsync(UpdateWebhookAddressModel data) =>
		await _notifyApi.UpdateWebhookAddressesAsync(data);

	public async Task<ApiResponse<ResponseModel.CreateWebhookModel>> UpdateWebhookStatusAsync(UpdateWebhookStatusModel data) =>
		await _notifyApi.UpdateWebhookStatusAsync(data);
}
