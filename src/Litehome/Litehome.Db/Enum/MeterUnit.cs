using System.ComponentModel.DataAnnotations;

namespace Litehome.Db.Enum;

public enum MeterUnit
{
	[Display(Name = "m³")]
	M3,
	[Display(Name = "kWh")]
	KWh,
	L,
}