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
			expense.OperationType = Operation.None;
		}
	}

	public async Task<bool> SaveExpenses()
	{
		foreach (var expense in Expenses)
		{
			expense.ExpenseCategory = null;
		}

		var result = await expenseRepository.CrudManyAsync(Expenses);
		await LoadExpenses();

		return result.All(x => x.Success);
	}

	public async Task<bool> RemoveCategoryFromAllExpenses(ExpenseCategory category)
	{
		await LoadExpenses();

		foreach (var expense in Expenses.Where(x => x.ExpenseCategoryId == category.Id))
		{
			expense.ExpenseCategory = null;
			expense.ExpenseCategoryId = null;
			expense.OperationType = Operation.Updated;
		}

		return await SaveExpenses();
	}

	public void UpdateExpenses(IEnumerable<Expense> expenses)
	{
		foreach (var expense in expenses)
		{
			var existing = Expenses.Find(x => x.Id == expense.Id);

			if (existing is null)
			{
				Expenses.Add(expense);
				continue;
			}

			existing.OperationType = expense.OperationType;
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