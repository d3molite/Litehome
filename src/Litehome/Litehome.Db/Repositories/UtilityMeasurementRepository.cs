using Demolite.Db.Interfaces;
using Litehome.Db.Context;
using Litehome.Db.Models.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Litehome.Db.Repositories;

public class UtilityMeasurementRepository(IDbContextFactory<LitehomeDbContext> contextFactory)
	: AbstractLitehomeRepository<UtilityMeasurement>(contextFactory), IDbRepository<UtilityMeasurement>;