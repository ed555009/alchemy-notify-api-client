using Alchemy.Notify.Api.Client.Configs;
using Alchemy.Notify.Api.Client.Interfaces;
using Alchemy.Notify.Api.Client.Models.Requests;
using Refit;
using ResponseModel = Alchemy.Notify.Api.Client.Models.Responses;

namespace Alchemy.Notify.Api.Client.Services;

public class NotifyService : INotifyService
{
	private readonly INotifyApi _notifyApi;
	private readonly NotifyApiConfig _notifyApiConfig;

	public NotifyService(INotifyApi notifyApi, NotifyApiConfig notifyApiConfig)
	{
		_notifyApi = notifyApi;
		_notifyApiConfig = notifyApiConfig;
	}

	public async Task<ApiResponse<ResponseModel.CreateWebhookModel>> CreateWebhookAsync(CreateWebhookModel data) =>
			await _notifyApi.CreateWebhookAsync(_notifyApiConfig.AuthToken, data);

	public async Task<ApiResponse<object?>> DeleteWebhookAsync(string webhookId) =>
		await _notifyApi.DeleteWebhookAsync(_notifyApiConfig.AuthToken, webhookId);

	public async Task<ApiResponse<ResponseModel.AllWebhooksModel>> GetAllWebhooksAsync() =>
		await _notifyApi.GetAllWebhooksAsync(_notifyApiConfig.AuthToken);

	public async Task<ApiResponse<object?>> ReplaceWebhookAddressesAsync(ReplaceWebhookAddressModel data) =>
		await _notifyApi.ReplaceWebhookAddressesAsync(_notifyApiConfig.AuthToken, data);

	public async Task<ApiResponse<object?>> UpdateWebhookAddressesAsync(UpdateWebhookAddressModel data) =>
		await _notifyApi.UpdateWebhookAddressesAsync(_notifyApiConfig.AuthToken, data);

	public async Task<ApiResponse<ResponseModel.CreateWebhookModel>> UpdateWebhookStatusAsync(UpdateWebhookStatusModel data) =>
		await _notifyApi.UpdateWebhookStatusAsync(_notifyApiConfig.AuthToken, data);
}
