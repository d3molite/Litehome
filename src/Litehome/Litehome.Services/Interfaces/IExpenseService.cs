using Litehome.Db.Models.Finance;
using Litehome.Services.Interfaces.Abstract;

namespace Litehome.Services.Interfaces;

public interface IExpenseService : IAbstractItemService<Expense>
{
	public Task<bool> RemoveCategoryFromAllExpenses(ExpenseCategory category);
	
	public decimal TotalSharedExpenses { get; }

	public decimal PercentageWeightedMonthly(decimal percentage);
	
	public decimal MemberSpending(HomeMember member, bool isSavings = false);

}