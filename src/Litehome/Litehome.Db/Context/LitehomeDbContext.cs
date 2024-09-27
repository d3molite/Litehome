using Litehome.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Litehome.Db.Context;

public class LitehomeDbContext(DbContextOptions<LitehomeDbContext> options) : DbContext(options)
{
	public DbSet<HomeMember> HomeMembers { get; init; } = null!;
}