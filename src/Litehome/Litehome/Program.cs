using Demolite.Db.Interfaces;
using MudBlazor.Services;
using Litehome.Components;
using Litehome.Db.Context;
using Litehome.Db.Interfaces;
using Litehome.Db.Models.Finance;
using Litehome.Db.Models.Utilities;
using Litehome.Db.Repositories;
using Litehome.Services.Classes;
using Litehome.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

var factory = app.Services.GetRequiredService<IDbContextFactory<LitehomeDbContext>>();

await using var db = await factory.CreateDbContextAsync();
await db.Database.MigrateAsync();

await app.RunAsync();
