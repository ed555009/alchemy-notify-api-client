using System.Net;
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
				"0x1f0bbe7bed347a8330d449b843f50844d4d35f90"
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
			WebhookId = "wh_tpyh33wlodqs0ybs",
			AddressesToAdd = new List<string>
			{
				"0x1f0bbe7bed347a8330d449b843f50844d4d35f90"
			},
			AddressesToRemove = new List<string>
			{
				"0x0f9458500f0fc57f83879ff627b69bffa3221f6c"
			}
		});

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}
