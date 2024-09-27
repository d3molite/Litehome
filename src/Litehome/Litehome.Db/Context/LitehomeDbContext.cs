using Litehome.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Litehome.Db.Context;

public class LitehomeDbContext(DbContextOptions<LitehomeDbContext> options) : DbContext(options)
{
	public DbSet<HomeMember> HomeMembers { get; init; } = null!;
	
	public DbSet<Income> Incomes { get; init; } = null!;
	
	public DbSet<Expense> Expenses { get; init; } = null!;
}