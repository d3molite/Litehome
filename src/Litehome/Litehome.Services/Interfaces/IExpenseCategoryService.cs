using Litehome.Db.Models;

namespace Litehome.Services.Interfaces;

public interface IExpenseCategoryService
{
	public List<ExpenseCategory> ExpenseCategories { get; set; }

	public Task LoadExpenseCategories();
	
	public Task SaveExpenseCategories();
	
	public void UpdateExpenseCategories(IEnumerable<ExpenseCategory> categories);
}