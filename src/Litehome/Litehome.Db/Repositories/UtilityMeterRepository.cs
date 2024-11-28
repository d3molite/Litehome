using Litehome.Db.Context;
using Litehome.Db.Interfaces;
using Litehome.Db.Models.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Litehome.Db.Repositories;

public class UtilityMeterRepository(IDbContextFactory<LitehomeDbContext> contextFactory)
	: AbstractLitehomeRepository<UtilityMeter>(contextFactory), IUtilityMeterRepository;