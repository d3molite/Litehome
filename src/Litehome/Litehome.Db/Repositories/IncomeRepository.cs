using Litehome.Db.Context;
using Litehome.Db.Interfaces;
using Litehome.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Litehome.Db.Repositories;

public class IncomeRepository(IDbContextFactory<LitehomeDbContext> contextFactory) : AbstractLitehomeRepository<Income>(contextFactory), IIncomeRepository
{
}