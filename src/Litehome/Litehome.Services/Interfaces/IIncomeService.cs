using Litehome.Db.Models;

namespace Litehome.Services.Interfaces;

public interface IIncomeService
{
	public List<Income> Incomes { get; set; }

	public Task LoadIncomes();

	public Task SaveIncomes();

	public void UpdateIncomes(IEnumerable<Income> incoming);
}