using Demolite.Db.Interfaces;
using Litehome.Db.Models.Finance;
using Litehome.Services.Classes.Abstract;
using Litehome.Services.Interfaces;

namespace Litehome.Services.Classes;

public class IncomeService(IDbRepository<Income> repository, IHomeMemberService homeMemberService)
	: AbstractItemService<Income>(repository), IIncomeService
{
	public override async Task Load()
	{
		await base.Load();

		foreach (var income in Items)
		{
			income.HomeMember = homeMemberService.Items.Find(m => m.Id == income.HomeMemberId);
		}
	}

	protected override void UpdateItem(Income existing, Income incoming)
	{
		existing.Amount = incoming.Amount;
	}

	public decimal MonthlyMemberIncome(HomeMember member)
		=> Items
			.Where(x => x.HomeMemberId == member.Id)
			.Sum(x => x.MonthlyAmount);

	public decimal TotalMonthlyIncome => Items.Sum(x => x.MonthlyAmount);

	public decimal MemberIncomePercentage(HomeMember member)
	{
		if (TotalMonthlyIncome > 0)
			return MonthlyMemberIncome(member) / TotalMonthlyIncome;

		return 0;
	}
}