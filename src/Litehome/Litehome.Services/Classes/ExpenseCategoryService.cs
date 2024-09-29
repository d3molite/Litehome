using Demolite.Db.Enum;
using Litehome.Db.Interfaces;
using Litehome.Db.Models;
using Litehome.Services.Interfaces;

namespace Litehome.Services.Classes;

public class ExpenseCategoryService(IExpenseCategoryRepository expenseCategoryRepository) : IExpenseCategoryService
{
	public List<ExpenseCategory> ExpenseCategories { get; set; } = [];

	public async Task LoadExpenseCategories()
	{
		ExpenseCategories.Clear();
		ExpenseCategories = (await expenseCategoryRepository.GetAllAsync()).ToList();
	}

	public async Task SaveExpenseCategories()
	{
		await expenseCategoryRepository.CrudManyAsync(ExpenseCategories);
		await LoadExpenseCategories();
	}

	public void UpdateExpenseCategories(IEnumerable<ExpenseCategory> categories)
	{
		foreach (var category in categories)
		{
			var existing = ExpenseCategories.Find(x => x.Id == category.Id);

			if (existing is null)
			{
				ExpenseCategories.Add(category);
				return;
			}

			existing.OperationType = Operation.Updated;
			existing.Name = category.Name;
		}
	}
}