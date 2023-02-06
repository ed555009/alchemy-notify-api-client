namespace Alchemy.Notify.Api.Client.Models.Notify;

public class ActivityModel
{
	public string? FromAddress { get; set; }
	public string? ToAddress { get; set; }
	public string? BlockNum { get; set; }
	public string? Hash { get; set; }
	public decimal? Value { get; set; }
	public string? Asset { get; set; }
	public string? Category { get; set; }
	public RawContractModel? RawContract { get; set; }
}
