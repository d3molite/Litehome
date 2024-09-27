using Lite.Db.Interfaces;
using Lite.Db.Repositories;
using Litehome.Db.Context;
using Microsoft.EntityFrameworkCore;

namespace Litehome.Db.Repositories;

public class AbstractLitehomeRepository<T>(IDbContextFactory<LitehomeDbContext> contextFactory)
	: AbstractBaseRepository<T, LitehomeDbContext>
	where T : class, IHasOperation
{
	protected override Task<LitehomeDbContext> GetContextAsync()
		=> contextFactory.CreateDbContextAsync();

	protected override LitehomeDbContext GetContext()
		=> contextFactory.CreateDbContext();
}