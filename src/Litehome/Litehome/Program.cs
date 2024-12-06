using ApexCharts;
using Demolite.Db.Interfaces;
using MudBlazor.Services;
using Litehome.Components;
using Litehome.Db.Context;
using Litehome.Db.Models.Finance;
using Litehome.Db.Models.Utilities;
using Litehome.Db.Repositories;
using Litehome.Services.Classes;
using Litehome.Services.Interfaces;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization();
System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("de-DE");
System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("de-DE");

// Add MudBlazor services
builder.Services.AddMudServices();

builder.Services.AddApexCharts(
	e => e.GlobalOptions = new ApexChartBaseOptions()
	{
		Theme = new Theme()
		{
			Palette = PaletteType.Palette2,
		},
		Chart = new Chart()
		{
			Height = "400px",
			Width = "100%",
			ForeColor = "#fff",
		},
	}
);

// Add services to the container.
builder
	.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

if (!Directory.Exists("./db"))
	Directory.CreateDirectory("./db");

builder.Services.AddDbContextFactory<LitehomeDbContext>(options => options.UseSqlite("DataSource=./db/home.db"));
builder.Services.AddDbContext<LitehomeDbContext>();

builder.Services.AddScoped<IDbRepository<HomeMember>, HomeMemberRepository>();
builder.Services.AddScoped<IDbRepository<Income>, IncomeRepository>();
builder.Services.AddScoped<IDbRepository<Expense>, ExpenseRepository>();
builder.Services.AddScoped<IDbRepository<ExpenseCategory>, ExpenseCategoryRepository>();

builder.Services.AddScoped<IDbRepository<UtilityMeter>, UtilityMeterRepository>();
builder.Services.AddScoped<IDbRepository<UtilityMeasurement>, UtilityMeasurementRepository>();

builder.Services.AddScoped<IHomeMemberService, HomeMemberService>();
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();

builder.Services.AddScoped<IUtilityMeterService, UtilityMeterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);

	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app
	.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

var factory = app.Services.GetRequiredService<IDbContextFactory<LitehomeDbContext>>();

await using var db = await factory.CreateDbContextAsync();
await db.Database.MigrateAsync();

await app.RunAsync();