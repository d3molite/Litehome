using Demolite.Db.Enum;
using Litehome.Db.Interfaces;
using Litehome.Db.Models;
using Litehome.Services.Interfaces;

namespace Litehome.Services.Classes;

public class IncomeService(IIncomeRepository incomeRepository, IHomeMemberService homeMemberService) : IIncomeService
{
	public List<Income> Incomes { get; set; } = [];

	public async Task LoadIncomes()
	{
		Incomes = (await incomeRepository.GetAllAsync()).ToList();

		foreach (var income in Incomes)
		{
			income.HomeMember = homeMemberService.Members.Find(m => m.Id == income.HomeMemberId);
		}
	}

	public async Task<bool> SaveIncomes()
	{
		var results = await incomeRepository.CrudManyAsync(Incomes);
		await LoadIncomes();

		return results.All(x => x.Success);
	}

	public void UpdateIncomes(IEnumerable<Income> incoming)
	{
		foreach (var income in incoming)
		{
			var existing = Incomes.Find(x => x.Id == income.Id);

			if (existing is null)
			{
				Incomes.Add(income);
				continue;
			}

			existing.OperationType = Operation.Updated;
			existing.Amount = income.Amount;
		}
	}
	
	public decimal MonthlyMemberIncome(HomeMember member)
		=> Incomes.Where(x => x.HomeMemberId == member.Id).Sum(x => x.MonthlyAmount);
	
	public decimal TotalMonthlyIncome => Incomes.Sum(x => x.MonthlyAmount);

	public decimal MemberIncomePercentage(HomeMember member)
	{
		if (TotalMonthlyIncome > 0)
			return MonthlyMemberIncome(member) / TotalMonthlyIncome;

		return 0;
	}
	
}