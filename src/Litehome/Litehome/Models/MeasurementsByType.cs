using Litehome.Db.Enum;

namespace Litehome.Models;

public class MeasurementsByType
{
	public UtilityType UtilityType { get; set; }

	public List<MeasurementsByYear> MeasurementByYears { get; set; } = [];
}

public class MeasurementsByYear
{
	public int Year { get; set; }
	
	public List<ConsumptionPerMonth> Measurements { get; set; } = [];
}

public class ConsumptionPerMonth
{
	public int Month { get; set; }
	
	public string MonthName { get; set; }
	
	public decimal? Consumption { get; set; }
}