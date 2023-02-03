using System.Text;
using System.Text.Json;
using Alchemy.Notify.Api.Client.Configs;
using Alchemy.Notify.Api.Client.Extensions;
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
	public void AddAlchemyNotifyApiServices_ShouldSucceed()
	{
		// Given
		var services = new ServiceCollection();
		var builder = new ConfigurationBuilder();
		var configuration = builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(_settings))).Build();

		// When
		ServicesExtensions.AddAlchemyNotifyApiServices(services, configuration);

		// Then
		Assert.Contains(services, x => x.ServiceType == typeof(INotifyApi));

		Assert.Contains(services, x => x.ServiceType == typeof(INotifyService)
								 && x.ImplementationType == typeof(NotifyService));
	}
}
