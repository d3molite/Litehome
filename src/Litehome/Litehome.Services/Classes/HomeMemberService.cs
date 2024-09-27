using Litehome.Db.Interfaces;
using Litehome.Db.Models;
using Litehome.Services.Interfaces;

namespace Litehome.Services.Classes;

public class HomeMemberService(IHomeMemberRepository homeMemberRepository) : IHomeMemberService
{
	public List<HomeMember> Members { get; set; } = [];

	public async Task LoadMembers()
	{
		Members = (await homeMemberRepository.GetAllAsync()).ToList();
	}

	public async Task SaveMembers()
	{
		await homeMemberRepository.CrudManyAsync(Members);
		await LoadMembers();
	}
}