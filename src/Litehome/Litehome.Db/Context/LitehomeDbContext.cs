using Litehome.Db.Models;
using Litehome.Db.Models.Finance;
using Litehome.Db.Models.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Litehome.Db.Context;

public class LitehomeDbContext(DbContextOptions<LitehomeDbContext> options) : DbContext(options)
{
	public DbSet<HomeMember> HomeMembers { get; init; } = null!;

	public DbSet<Income> Incomes { get; init; } = null!;

	public DbSet<Expense> Expenses { get; init; } = null!;

	public DbSet<ExpenseCategory> ExpenseCategories { get; init; } = null!;

	public DbSet<UtilityMeter> UtilityMeters { get; init; } = null!;
	
	public DbSet<UtilityMeasurement> UtilityMeasurements { get; init; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.Entity<Expense>()
			.HasOne(x => x.HomeMember)
			.WithMany(x => x.Expenses)
			.HasForeignKey(x => x.HomeMemberId);

		modelBuilder
			.Entity<Expense>()
			.HasOne(x => x.ExpenseCategory)
			.WithMany(x => x.Expenses)
			.HasForeignKey(x => x.ExpenseCategoryId);

		modelBuilder
			.Entity<ExpenseCategory>()
			.HasData(
				new ExpenseCategory()
				{
					Id = "fb7cafed-001d-44ad-8fa7-83bb3cbea7bd",
					Name = "General",
				}
			);

		modelBuilder
			.Entity<UtilityMeasurement>()
			.HasOne(x => x.Meter)
			.WithMany(x => x.Measurements)
			.HasForeignKey(x => x.MeterId);
	}
}