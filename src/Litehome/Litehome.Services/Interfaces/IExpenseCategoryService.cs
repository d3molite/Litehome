using Litehome.Db.Models;
using Litehome.Db.Models.Finance;

namespace Litehome.Services.Interfaces;

public interface IExpenseCategoryService
{
	public List<ExpenseCategory> ExpenseCategories { get; set; }

	public Task LoadExpenseCategories();
	
	public Task<bool> SaveExpenseCategories();
	
	public void UpdateExpenseCategories(IEnumerable<ExpenseCategory> categories);

	public Task DeleteExpenseCategory();
}