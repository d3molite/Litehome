using Demolite.Db.Interfaces;
using Litehome.Db.Models.Finance;
using Litehome.Services.Classes.Abstract;
using Litehome.Services.Interfaces;

namespace Litehome.Services.Classes;

public class HomeMemberService(IDbRepository<HomeMember> repository)
	: AbstractItemService<HomeMember>(repository), IHomeMemberService
{
	protected override void UpdateItem(HomeMember existing, HomeMember incoming)
	{
		existing.Name = incoming.Name;
	}
}