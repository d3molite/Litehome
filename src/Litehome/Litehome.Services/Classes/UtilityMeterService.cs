using Demolite.Db.Interfaces;
using Litehome.Db.Models.Utilities;
using Litehome.Services.Classes.Abstract;
using Litehome.Services.Interfaces;

namespace Litehome.Services.Classes;

public class UtilityMeterService(IDbRepository<UtilityMeter> repository) : AbstractItemService<UtilityMeter>(repository), IUtilityMeterService
{
	protected override void UpdateItem(UtilityMeter existing, UtilityMeter incoming)
	{
		existing.Name = incoming.Name;
		existing.Unit = incoming.Unit;
		existing.UtilityType = incoming.UtilityType;
		existing.Active = incoming.Active;
	}
}