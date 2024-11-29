using Demolite.Db.Interfaces;
using Litehome.Db.Context;
using Litehome.Db.Models.Finance;
using Microsoft.EntityFrameworkCore;

namespace Litehome.Db.Repositories;

public class HomeMemberRepository(IDbContextFactory<LitehomeDbContext> contextFactory)
	: AbstractLitehomeRepository<HomeMember>(contextFactory), IDbRepository<HomeMember>;