# Alchemy.Notify.Api.Client

[![GitHub](https://img.shields.io/github/license/ed555009/fireblocks-api)](LICENSE)
![Build Status](https://dev.azure.com/edwang/github/_apis/build/status/fireblocks-api?branchName=master)
[![Nuget](https://img.shields.io/nuget/v/Fireblocks.Api)](https://www.nuget.org/packages/Fireblocks.Api)

![Coverage](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=fireblocks-api&metric=coverage&token=edde8bb242d724653b64036f7a3fe6cf539b3a1a)
![Quality Gate Status](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=fireblocks-api&metric=alert_status&token=edde8bb242d724653b64036f7a3fe6cf539b3a1a)
![Reliability Rating](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=fireblocks-api&metric=reliability_rating&token=edde8bb242d724653b64036f7a3fe6cf539b3a1a)
![Security Rating](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=fireblocks-api&metric=security_rating&token=edde8bb242d724653b64036f7a3fe6cf539b3a1a)
![Vulnerabilities](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=fireblocks-api&metric=vulnerabilities&token=edde8bb242d724653b64036f7a3fe6cf539b3a1a)

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

### Add configs & services

```csharp
using Alchemy.Notify.Api.Client.Extensions;

ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
	services
		.AddAlchemyNotifyApiConfig(configuration);
		.AddAlchemyNotifyApiServices(configuration);
}
```

`AddAlchemyNotifyApiServices()` injects as SINGLETON, for web application, you can inject as SCOPED by using `AddScopedAlchemyNotifyApiServices()` instead.

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
