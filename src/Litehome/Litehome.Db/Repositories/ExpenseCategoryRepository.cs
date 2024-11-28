using Litehome.Db.Context;
using Litehome.Db.Interfaces;
using Litehome.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Litehome.Db.Repositories;

public class ExpenseCategoryRepository(IDbContextFactory<LitehomeDbContext> contextFactory) 
	: AbstractLitehomeRepository<ExpenseCategory>(contextFactory), IExpenseCategoryRepository;