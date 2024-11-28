using Demolite.Db.Models;
using Litehome.Db.Enum;

namespace Litehome.Db.Models.Utilities;

public class UtilityMeter : AbstractDbItem
{
	public string Name { get; set; } = "Please enter a name";
	
	public bool Active { get; set; }
	
	public MeterUnit Unit { get; set; }
	
	public UtilityType UtilityType { get; set; }

	public virtual ICollection<UtilityMeasurement> Measurements { get; set; } = [];
}