using Demolite.Db.Models;

namespace Litehome.Db.Models;

public class ExpenseCategory : AbstractDbItem
{
	public string Name { get; set; }
	
	public virtual ICollection<Expense> Expenses { get; set; }
}