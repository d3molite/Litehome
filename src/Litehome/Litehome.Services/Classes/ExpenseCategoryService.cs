using Demolite.Db.Enum;
using Litehome.Db.Interfaces;
using Litehome.Db.Models;
using Litehome.Db.Models.Finance;
using Litehome.Services.Interfaces;

namespace Litehome.Services.Classes;

public class ExpenseCategoryService(IExpenseCategoryRepository expenseCategoryRepository) : IExpenseCategoryService
{
	public List<ExpenseCategory> ExpenseCategories { get; set; } = [];

	public async Task LoadExpenseCategories()
	{
		ExpenseCategories.Clear();
		ExpenseCategories = (await expenseCategoryRepository.GetAllAsync()).ToList();

		foreach (var category in ExpenseCategories)
		{
			category.OperationType = Operation.None;
		}
	}

	public async Task<bool> SaveExpenseCategories()
	{
		var results = await expenseCategoryRepository.CrudManyAsync(ExpenseCategories);
		await LoadExpenseCategories();

		return results.All(x => x.Success);
	}

	public void UpdateExpenseCategories(IEnumerable<ExpenseCategory> categories)
	{
		foreach (var category in categories)
		{
			var existing = ExpenseCategories.Find(x => x.Id == category.Id);

			if (existing is null)
			{
				ExpenseCategories.Add(category);
				continue;
			}
			
			existing.OperationType = category.OperationType;
			existing.Name = category.Name;
		}
	}

	public async Task DeleteExpenseCategory()
	{
		
	}
}