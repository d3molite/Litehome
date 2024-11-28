using Demolite.Db.Models;

namespace Litehome.Db.Models.Utilities;

public class UtilityMeasurement : AbstractDbItem
{
	public virtual UtilityMeter Meter { get; set; }
	
	public string MeterId { get; set; }
	
	public DateOnly MeasurementDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
	
	public double MeasurementValue { get; set; }
}