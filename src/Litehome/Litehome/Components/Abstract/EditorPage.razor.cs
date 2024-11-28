using Demolite.Db.Enum;
using Demolite.Db.Interfaces;

namespace Litehome.Components.Abstract;

public abstract partial class EditorPage<T> where T : IHasOperation
{
	protected List<T> Items { get; set; } = [];
	
	protected bool HasUnsavedChanges { get; set; }

	protected virtual void Add()
	{
		Items.Add(CreateItem());
		CheckForUnsavedChanges();
	}

	protected abstract T CreateItem();
	
	protected virtual void Delete(T item)
	{
		if (item.OperationType is Operation.Created)
			Items.Remove(item);

		else
			item.OperationType = Operation.Removed;
	}
	
	protected virtual void CheckForUnsavedChanges()
	{
		HasUnsavedChanges = Items.Any(x => x.OperationType != Operation.None);
	}

	protected virtual void ItemUpdated(T item)
	{
		if (item.OperationType != Operation.Created)
			item.OperationType = Operation.Updated;
		
		CheckForUnsavedChanges();
	}
}