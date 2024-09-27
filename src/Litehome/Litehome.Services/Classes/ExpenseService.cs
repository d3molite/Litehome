using Lite.Db.Enum;
using Litehome.Db.Interfaces;
using Litehome.Db.Models;
using Litehome.Services.Interfaces;

namespace Litehome.Services.Classes;

public class ExpenseService(IExpenseRepository expenseRepository, IHomeMemberService homeMemberService) : IExpenseService
{
	public List<Expense> Expenses { get; set; } = [];

	public async Task LoadExpenses()
	{
		Expenses = (await expenseRepository.GetAllAsync()).ToList();

		foreach (var expense in Expenses.Where(x => !x.IsShared))
		{
			expense.HomeMember = homeMemberService.Members.Find(m => m.Id == expense.HomeMemberId);
		}
	}

	public async Task SaveExpenses()
	{
		await expenseRepository.CrudManyAsync(Expenses);
		await LoadExpenses();
	}

	public void UpdateExpenses(IEnumerable<Expense> expenses)
	{
		foreach (var expense in expenses)
		{
			var existing = Expenses.Find(x => x.Id == expense.Id);

			if (existing is null)
			{
				Expenses.Add(expense);
				return;
			}

			existing.OperationType = Operation.Updated;
			existing.Amount = expense.Amount;
		}
	}
}