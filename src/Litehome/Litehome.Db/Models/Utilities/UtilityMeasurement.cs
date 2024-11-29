using System.ComponentModel.DataAnnotations.Schema;
using Demolite.Db.Models;

namespace Litehome.Db.Models.Utilities;

public class UtilityMeasurement : AbstractDbItem
{
	public virtual UtilityMeter Meter { get; set; }
	
	public string MeterId { get; set; }
	
	[NotMapped]
	public DateTime? DatePickerValue
	{
		get => MeasurementDate.ToDateTime(new TimeOnly());
		set
		{
			if (value is null)
				return;
			
			MeasurementDate = DateOnly.FromDateTime(value.Value);
		}
	}

	public DateOnly MeasurementDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

	[NotMapped]
	public DateOnly MeasurementMonth => MeasurementDate.AddMonths(-1);
	
	public double MeasurementValue { get; set; }

	public double Consumption { get; set; } = 0;
}