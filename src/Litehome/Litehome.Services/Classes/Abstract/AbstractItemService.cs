using System.Transactions;
using Demolite.Db.Enum;
using Demolite.Db.Interfaces;
using Litehome.Services.Interfaces.Abstract;

namespace Litehome.Services.Classes.Abstract;

public abstract class AbstractItemService<T>(IDbRepository<T> repository) : IAbstractItemService<T>
	where T : class, IHasOperation, IDbItem
{
	public List<T> Items { get; set; } = [];

	public virtual async Task Load()
	{
		Items.Clear();
		Items = (await repository.GetAllAsync()).ToList();

		foreach (var item in Items)
		{
			item.OperationType = Operation.None;
		}
	}

	public virtual async Task<bool> Save()
	{
		using var scope = new TransactionScope();

		try
		{
			var results = await repository.CrudManyAsync(Items);
			scope.Complete();
			return results.All(x => x.Success);
		}
		catch (Exception e)
		{
			
		}
		
		return false;
	}

	protected abstract void UpdateItem(T existing, T incoming);

	public virtual void Update(IEnumerable<T> incoming)
	{
		foreach (var item in incoming)
		{
			var existing = Items.Find(x => x.Id == item.Id);

			if (existing is null)
			{
				Items.Add(item);
				continue;
			}
			
			existing.OperationType = item.OperationType;
			UpdateItem(existing, item);
		}
	}
}