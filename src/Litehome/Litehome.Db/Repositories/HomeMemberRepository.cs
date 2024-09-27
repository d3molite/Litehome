using Litehome.Db.Context;
using Litehome.Db.Interfaces;
using Litehome.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Litehome.Db.Repositories;

public class HomeMemberRepository(IDbContextFactory<LitehomeDbContext> contextFactory)
	: AbstractLitehomeRepository<HomeMember>(contextFactory), IHomeMemberRepository
{
}