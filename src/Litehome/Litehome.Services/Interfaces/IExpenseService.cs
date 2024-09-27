using Litehome.Db.Models;

namespace Litehome.Services.Interfaces;

public interface IExpenseService
{
	public List<Expense> Expenses { get; set; }

	public Task LoadExpenses();

	public Task SaveExpenses();
	
	public void UpdateExpenses(IEnumerable<Expense> expenses);
}