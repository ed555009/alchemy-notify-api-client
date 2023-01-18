using System.Text;
using System.Text.Json;
using Alchemy.Notify.Api.Client.Configs;
using Alchemy.Notify.Api.Client.Extensions;
using Alchemy.Notify.Api.Client.Handlers;
using Alchemy.Notify.Api.Client.Interfaces;
using Alchemy.Notify.Api.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Alchemy.Notify.Api.Client.Tests;

public class ServicesExtensionTests : BaseServiceTests
{
	private readonly string _settings;

	public ServicesExtensionTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_settings = JsonSerializer.Serialize(new
		{
			Alchemy = new
			{
				NotifyApi = new
				{
					NotifyApiConfig.BaseUrl,
					NotifyApiConfig.AuthToken
				}
			}
		});
	}

	[Fact]
	public void AddAlchemyNotifyApiConfig_ShouldSucceed()
	{
		// Given
		var services = new ServiceCollection();
		var builder = new ConfigurationBuilder();
		var configuration = builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(_settings))).Build();

		// When
		ServicesExtensions.AddAlchemyNotifyApiConfig(services, configuration);
		var provider = services.BuildServiceProvider();
		var notifyApiConfig = provider.GetRequiredService<NotifyApiConfig>();

		// Then
		Assert.Equal(NotifyApiConfig.BaseUrl, notifyApiConfig.BaseUrl);
		Assert.Equal(NotifyApiConfig.AuthToken, notifyApiConfig.AuthToken);
	}

	[Fact]
	public void AddAlchemyNotifyApiServices_ShouldSucceed()
	{
		AddServicesTests();
	}

	[Fact]
	public void AddScopedAlchemyNotifyApiServices_ShouldSucceed()
	{
		AddServicesTests();
	}

	void AddServicesTests()
	{
		// Given
		var services = new ServiceCollection();
		var builder = new ConfigurationBuilder();
		var configuration = builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(_settings))).Build();

		// When
		ServicesExtensions.AddAlchemyNotifyApiServices(services, configuration);

		// Then
		Assert.Contains(services, x => x.ServiceType == typeof(INotifyApi));

		Assert.Contains(services, x => x.ImplementationType == typeof(AuthHeaderHandler));

		Assert.Contains(services, x => x.ServiceType == typeof(INotifyService)
								 && x.ImplementationType == typeof(NotifyService));
	}
}
