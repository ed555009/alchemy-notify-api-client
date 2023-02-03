using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemy.Notify.Api.Client.Configs;
using Alchemy.Notify.Api.Client.Interfaces;
using Alchemy.Notify.Api.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Alchemy.Notify.Api.Client.Extensions;

public static class ServicesExtensions
{
	public static IServiceCollection AddAlchemyNotifyApiServices(
		this IServiceCollection services,
		IConfiguration configuration,
		ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
	{
		var config = GetNotifyApiConfig(configuration);
		var refitSettings = GetRefitSettings();

		_ = services
			.AddSingleton(config)
			.AddRefitClient<INotifyApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/api"));

		_ = services.AddSingleton<INotifyService, NotifyService>();

		return serviceLifetime switch
		{
			ServiceLifetime.Scoped => services.AddScoped<INotifyService, NotifyService>(),
			ServiceLifetime.Transient => services.AddTransient<INotifyService, NotifyService>(),
			_ => services.AddSingleton<INotifyService, NotifyService>()
		};
	}

	static NotifyApiConfig GetNotifyApiConfig(IConfiguration configuration) =>
		configuration
			.GetSection("Alchemy")
			.GetSection("NotifyApi")
			.Get<NotifyApiConfig>();

	static RefitSettings GetRefitSettings() =>
		new()
		{
			ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
			{
				Converters =
				{
					new JsonStringEnumConverter()
				},
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				ReferenceHandler = ReferenceHandler.IgnoreCycles,
				NumberHandling = JsonNumberHandling.AllowReadingFromString,
				PropertyNameCaseInsensitive = true
			})
		};
}
