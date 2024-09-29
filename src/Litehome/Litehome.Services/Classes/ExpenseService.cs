using Demolite.Db.Enum;
using Litehome.Db.Interfaces;
using Litehome.Db.Models;
using Litehome.Services.Interfaces;

namespace Litehome.Services.Classes;

public class ExpenseService(
	IExpenseRepository expenseRepository,
	IHomeMemberService homeMemberService,
	IExpenseCategoryService expenseCategoryService
) : IExpenseService
{
	public List<Expense> Expenses { get; set; } = [];

	public async Task LoadExpenses()
	{
		Expenses = (await expenseRepository.GetAllAsync()).ToList();

		foreach (var expense in Expenses)
		{
			expense.HomeMember = homeMemberService.Members.Find(m => m.Id == expense.HomeMemberId);
			expense.ExpenseCategory = expenseCategoryService.ExpenseCategories.Find(c => c.Id == expense.ExpenseCategoryId);
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
			existing.ExpenseCategory = expense.ExpenseCategory;
			existing.Date = expense.Date;
			existing.Amount = expense.Amount;
		}
	}

	public decimal TotalSharedExpenses => Expenses.Where(x => x.HomeMemberId is null).Sum(x => x.MonthlyAmount);

	public decimal PercentageWeightedMonthly(decimal percentage)
		=> percentage * TotalSharedExpenses;

	public decimal MemberSpending(HomeMember member, bool isSavings = false)
		=> Expenses.Where(x => x.HomeMember == member && x.IsSavings == isSavings).Sum(x => x.MonthlyAmount);
}