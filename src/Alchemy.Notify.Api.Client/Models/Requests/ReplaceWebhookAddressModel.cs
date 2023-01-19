namespace Alchemy.Notify.Api.Client.Models.Requests;

public class ReplaceWebhookAddressModel : BaseWebhookIdRequestModel
{
	public IEnumerable<string> Addresses { get; set; } = new List<string>();
}
