using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemy.Notify.Api.Client.Configs;
using Alchemy.Notify.Api.Client.Handlers;
using Alchemy.Notify.Api.Client.Interfaces;
using Alchemy.Notify.Api.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Alchemy.Notify.Api.Client.Extensions;

public static class ServicesExtensions
{
	public static IServiceCollection AddAlchemyNotifyApiConfig(
		this IServiceCollection services,
		IConfiguration configuration) =>
			services.AddSingleton(configuration.GetSection("Alchemy")
				.GetSection("NotifyApi")
				.Get<NotifyApiConfig>());

	public static IServiceCollection AddAlchemyNotifyApiServices(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		var config = GetNotifyApiConfig(configuration);
		var refitSettings = GetRefitSettings();

		_ = services.AddSingleton<AuthHeaderHandler>();

		_ = services
			.AddRefitClient<INotifyApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/api"))
			.AddHttpMessageHandler<AuthHeaderHandler>();

		_ = services.AddSingleton<INotifyService, NotifyService>();

		return services;
	}

	public static IServiceCollection AddScopedAlchemyNotifyApiServices(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		var config = GetNotifyApiConfig(configuration);
		var refitSettings = GetRefitSettings();

		_ = services.AddScoped<AuthHeaderHandler>();

		_ = services
			.AddRefitClient<INotifyApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/api"))
			.AddHttpMessageHandler<AuthHeaderHandler>();

		_ = services.AddScoped<INotifyService, NotifyService>();

		return services;
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
