using Litehome.Db.Models;

namespace Litehome.Services.Interfaces;

public interface IExpenseService
{
	public List<Expense> Expenses { get; set; }

	public Task LoadExpenses();

	public Task<bool> SaveExpenses();

	public Task<bool> RemoveCategoryFromAllExpenses(ExpenseCategory category);
	
	public void UpdateExpenses(IEnumerable<Expense> expenses);
	
	public decimal TotalSharedExpenses { get; }

	public decimal PercentageWeightedMonthly(decimal percentage);
	
	public decimal MemberSpending(HomeMember member, bool isSavings = false);

}