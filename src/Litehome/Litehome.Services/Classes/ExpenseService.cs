using Demolite.Db.Enum;
using Demolite.Db.Interfaces;
using Litehome.Db.Models.Finance;
using Litehome.Services.Classes.Abstract;
using Litehome.Services.Interfaces;

namespace Litehome.Services.Classes;

public class ExpenseService(
	IDbRepository<Expense> repository,
	IHomeMemberService homeMemberService,
	IExpenseCategoryService expenseCategoryService
) : AbstractItemService<Expense>(repository), IExpenseService
{
	public override async Task Load()
	{
		await base.Load();

		foreach (var expense in Items)
		{
			expense.HomeMember = homeMemberService.Items.Find(m => m.Id == expense.HomeMemberId);
			expense.ExpenseCategory = expenseCategoryService.Items.Find(c => c.Id == expense.ExpenseCategoryId);
			expense.OperationType = Operation.None;
		}
	}

	public override async Task<bool> Save()
	{
		foreach (var expense in Items)
		{
			expense.ExpenseCategory = null;
		}

		return await base.Save();
	}

	protected override void UpdateItem(Expense existing, Expense incoming)
	{
		existing.ExpenseCategory = incoming.ExpenseCategory;
		existing.Date = incoming.Date;
		existing.Amount = incoming.Amount;
	}
	
	public async Task<bool> RemoveCategoryFromAllExpenses(ExpenseCategory category)
	{
		await Load();

		foreach (var expense in Items.Where(x => x.ExpenseCategoryId == category.Id))
		{
			expense.ExpenseCategory = null;
			expense.ExpenseCategoryId = null;
			expense.OperationType = Operation.Updated;
		}

		return await Save();
	}

	public decimal TotalSharedExpenses => Items.Where(x => x.HomeMemberId is null).Sum(x => x.MonthlyAmount);

	public decimal PercentageWeightedMonthly(decimal percentage)
		=> percentage * TotalSharedExpenses;

	public decimal MemberSpending(HomeMember member, bool isSavings = false)
		=> Items.Where(x => x.HomeMember == member && x.IsSavings == isSavings).Sum(x => x.MonthlyAmount);
}