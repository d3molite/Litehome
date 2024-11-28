using Litehome.Db.Models.Utilities;

namespace Litehome.Services.Interfaces;

public interface IUtilityMeterService
{
	public List<UtilityMeter> UtilityMeters { get; set; }
}