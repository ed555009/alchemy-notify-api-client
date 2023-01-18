using Alchemy.Notify.Api.Client.Configs;

namespace Alchemy.Notify.Api.Client.Handlers;

public class AuthHeaderHandler : DelegatingHandler
{
	private readonly NotifyApiConfig _config;

	public AuthHeaderHandler(NotifyApiConfig config)
	{
		if (string.IsNullOrEmpty(config.AuthToken))
			throw new ArgumentException(nameof(config.AuthToken));

		_config = config;
		InnerHandler = new HttpClientHandler();
	}

	protected override async Task<HttpResponseMessage> SendAsync(
		HttpRequestMessage request,
		CancellationToken cancellationToken)
	{
		request.Headers.Add("X-Alchemy-Token", _config.AuthToken);

		return await base.SendAsync(request, cancellationToken);
	}
}
