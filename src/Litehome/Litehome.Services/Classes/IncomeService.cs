using Lite.Db.Enum;
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

	public async Task SaveIncomes()
	{
		await incomeRepository.CrudManyAsync(Incomes);
		await LoadIncomes();
	}

	public void UpdateIncomes(IEnumerable<Income> incoming)
	{
		foreach (var income in incoming)
		{
			var existing = Incomes.Find(x => x.Id == income.Id);

			if (existing is null)
			{
				Incomes.Add(income);
				return;
			}

			existing.OperationType = Operation.Updated;
			existing.Amount = income.Amount;
		}
	}
}