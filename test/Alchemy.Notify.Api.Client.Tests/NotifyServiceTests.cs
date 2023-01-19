using System.Net;
using Alchemy.Notify.Api.Client.Configs;
using Alchemy.Notify.Api.Client.Enums;
using Alchemy.Notify.Api.Client.Interfaces;
using Alchemy.Notify.Api.Client.Services;
using Xunit.Abstractions;
using RequestModel = Alchemy.Notify.Api.Client.Models.Requests;
using ResponseModel = Alchemy.Notify.Api.Client.Models.Responses;

namespace Alchemy.Notify.Api.Client.Tests;

public class NotifyServiceTests : BaseServiceTests
{
	private readonly Mock<INotifyApi> _notifyApiMock;
	private readonly INotifyService _notifyService;

	private readonly string _webhookId = "wh_tpyh33wlodqs0ybs";
	private readonly string _address1 = "0x1f0bbe7bed347a8330d449b843f50844d4d35f90";
	private readonly string _address2 = "0x1f0bbe7bed347a8330d449b843f50844d4d35f91";

	public NotifyServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_notifyApiMock = new Mock<INotifyApi>();
		_notifyService = new NotifyService(_notifyApiMock.Object);
	}

	[Fact]
	public async void GetAllWebhooksAsync_ShouldSucceed()
	{
		// Given
		_ = _notifyApiMock
			.Setup(x => x.GetAllWebhooksAsync())
			.Returns(CreateResponse<ResponseModel.AllWebhooksModel>(HttpStatusCode.OK));

		// When
		var result = await _notifyService.GetAllWebhooksAsync();

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async void CreateWebhookAsync_ShouldSucceed()
	{
		// Given
		_ = _notifyApiMock
			.Setup(x => x.CreateWebhookAsync(It.IsAny<RequestModel.CreateWebhookModel>()))
			.Returns(CreateResponse<ResponseModel.CreateWebhookModel>(HttpStatusCode.OK));

		// When
		var result = await _notifyService.CreateWebhookAsync(new RequestModel.CreateWebhookModel
		{
			Network = NetworkType.ETH_GOERLI,
			Type = WebhookType.ADDRESS_ACTIVITY,
			Url = "https://localhost:8888",
			Addresses = new List<string>
			{
				_address1
			}
		});

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async void UpdateWebhookAddressesAsync_ShouldSucceed()
	{
		// Given
		_ = _notifyApiMock
			.Setup(x => x.UpdateWebhookAddressesAsync(It.IsAny<RequestModel.UpdateWebhookAddressModel>()))
			.Returns(CreateEmptyResponse(HttpStatusCode.OK));

		// When
		var result = await _notifyService.UpdateWebhookAddressesAsync(new RequestModel.UpdateWebhookAddressModel
		{
			WebhookId = _webhookId,
			AddressesToAdd = new List<string>
			{
				_address1
			},
			AddressesToRemove = new List<string>
			{
				_address2
			}
		});

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async void DeleteWebhookAsync_ShouldSucceed()
	{
		// Given
		_ = _notifyApiMock
			.Setup(x => x.DeleteWebhookAsync(It.IsAny<string>()))
			.Returns(CreateEmptyResponse(HttpStatusCode.OK));

		// When
		var result = await _notifyService.DeleteWebhookAsync("");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async void ReplaceWebhookAddressesAsync_ShouldSucceedAsync()
	{
		// Given
		_ = _notifyApiMock
			.Setup(x => x.ReplaceWebhookAddressesAsync(It.IsAny<RequestModel.ReplaceWebhookAddressModel>()))
			.Returns(CreateEmptyResponse(HttpStatusCode.OK));

		// When
		var result = await _notifyService.ReplaceWebhookAddressesAsync(new RequestModel.ReplaceWebhookAddressModel
		{
			WebhookId = _webhookId,
			Addresses = new List<string>
			{
				_address1,
				_address2
			}
		});

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}
