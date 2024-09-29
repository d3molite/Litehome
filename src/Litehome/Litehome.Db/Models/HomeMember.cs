using System.ComponentModel.DataAnnotations;
using Demolite.Db.Models;

namespace Litehome.Db.Models;

public class HomeMember : AbstractDbItem
{
	[Required]
	[MaxLength(128)]
	public required string Name { get; set; }

	public virtual ICollection<Income> Incomes { get; set; } = [];
	
	public virtual ICollection<Expense> Expenses { get; set; } = [];
}