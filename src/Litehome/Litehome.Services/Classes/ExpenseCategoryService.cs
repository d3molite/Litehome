using Demolite.Db.Interfaces;
using Litehome.Db.Models.Finance;
using Litehome.Services.Classes.Abstract;
using Litehome.Services.Interfaces;

namespace Litehome.Services.Classes;

public class ExpenseCategoryService(IDbRepository<ExpenseCategory> repository)
	: AbstractItemService<ExpenseCategory>(repository), IExpenseCategoryService
{

	protected override void UpdateItem(ExpenseCategory existing, ExpenseCategory incoming)
		=> existing.Name = incoming.Name;
}