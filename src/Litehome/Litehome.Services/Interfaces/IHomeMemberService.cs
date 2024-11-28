using Litehome.Db.Models;
using Litehome.Db.Models.Finance;

namespace Litehome.Services.Interfaces;

public interface IHomeMemberService
{
	public List<HomeMember> Members { get; set; }

	public Task LoadMembers();

	public Task SaveMembers();
}