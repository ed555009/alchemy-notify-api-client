# Alchemy.Notify.Api.Client

[![GitHub](https://img.shields.io/github/license/ed555009/alchemy-notify-api-client)](LICENSE)
![Build Status](https://dev.azure.com/edwang/github/_apis/build/status/alchemy-notify-api-client?branchName=master)
[![Nuget](https://img.shields.io/nuget/v/Alchemy.Notify.Api.Client)](https://www.nuget.org/packages/Alchemy.Notify.Api.Client)

![Coverage](https://sonarcloud.io/api/project_badges/measure?project=alchemy-notify-api-client&metric=coverage)
![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=alchemy-notify-api-client&metric=alert_status)
![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=alchemy-notify-api-client&metric=reliability_rating)
![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=alchemy-notify-api-client&metric=security_rating)
![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=alchemy-notify-api-client&metric=vulnerabilities)

## Description

This is a .NET6 library for interacting with the [Alchemy](https://www.alchemy.com/) Notify Api.

## Quick start

### Installation

```bash
dotnet add package Alchemy.Notify.Api.Client
```

### Appsettings.json

```json
{
	"Alchemy": {
		"NotifyApi": {
			"BaseUrl": "https://dashboard.alchemy.com",
			"AuthToken": "YOUR_ALCHEMY_AUTH_TOKEN"
		}
	}
}
```

### Add services

```csharp
using Alchemy.Notify.Api.Client.Extensions;

ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
	// this injects as SINGLETON
	services.AddAlchemyNotifyApiServices(configuration);

	// you can also inject as SCOPED or TRANSIENT by specifying the ServiceLifetime
	services.AddAlchemyNotifyApiServices(configuration, ServiceLifetime.Scoped);
}
```

### Using services

```csharp
using Alchemy.Notify.Api.Client.Interfaces;
using Alchemy.Notify.Api.Client.Services;

public class MyProcess
{
	private readonly INotifyService _notifyService;

	public MyProcess(INotifyService notifyService) =>
		_notifyService = notifyService;

	public async Task GetAllWebhooksAsync()
	{
		var webhooks = await _notifyService.GetAllWebhooksAsync();
	}
}
```

## Reference

- [Alchemy Notify Api](https://docs.alchemy.com/reference/notify-api-quickstart)
