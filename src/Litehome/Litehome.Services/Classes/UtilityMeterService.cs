using Demolite.Db.Enum;
using Demolite.Db.Interfaces;
using Litehome.Db.Models.Utilities;
using Litehome.Services.Classes.Abstract;
using Litehome.Services.Interfaces;

namespace Litehome.Services.Classes;

public class UtilityMeterService(
	IDbRepository<UtilityMeter> repository,
	IDbRepository<UtilityMeasurement> measurementRepository) : AbstractItemService<UtilityMeter>(repository), IUtilityMeterService
{
	public override async Task Load()
	{
		var measurements = await measurementRepository.GetAllAsync();

		foreach (var measurement in measurements)
		{
			measurement.OperationType = Operation.None;
		}
		
		await base.Load();

		foreach (var item in Items)
		{
			item.Measurements = measurements.Where(m => m.MeterId == item.Id).OrderBy(x => x.MeasurementDate).ToList();
		}
	}
	protected override void UpdateItem(UtilityMeter existing, UtilityMeter incoming)
	{
		existing.Name = incoming.Name;
		existing.Unit = incoming.Unit;
		existing.UtilityType = incoming.UtilityType;
		existing.Active = incoming.Active;
		existing.Measurements = [];
	}
}