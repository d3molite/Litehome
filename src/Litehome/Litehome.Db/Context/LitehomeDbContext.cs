using Litehome.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Litehome.Db.Context;

public class LitehomeDbContext(DbContextOptions<LitehomeDbContext> options) : DbContext(options)
{
	public DbSet<HomeMember> HomeMembers { get; init; } = null!;
	
	public DbSet<Income> Incomes { get; init; } = null!;
	
	public DbSet<Expense> Expenses { get; init; } = null!;
	
	public DbSet<ExpenseCategory> ExpenseCategories { get; init; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Expense>()
					.HasOne(x => x.HomeMember)
					.WithMany(x => x.Expenses)
					.HasForeignKey(x => x.HomeMemberId);

		modelBuilder
			.Entity<ExpenseCategory>()
			.HasData(new ExpenseCategory() {
						Name = "General",
					}
			);
	}
}