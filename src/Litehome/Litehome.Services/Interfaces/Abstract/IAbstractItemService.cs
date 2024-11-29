using Demolite.Db.Interfaces;

namespace Litehome.Services.Interfaces.Abstract;

public interface IAbstractItemService<T> where T: IHasOperation
{
	public List<T> Items { get; set; }
	
	public Task Load();
	
	public Task<bool> Save();

	public void Update(IEnumerable<T> incoming);
}