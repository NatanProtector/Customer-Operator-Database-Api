using CustomerOperatorDatabaseApi.DBContexts;
using CustomerOperatorDatabaseApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddControllersWithViews();

// Add DbContext with SQLite
builder.Services.AddDbContext<SQLiteContext>(options =>
    options.UseSqlite("Data Source=app.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

// Map controllers to endpoints 
app.MapControllers();

// Map default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}"
);

app.Run();
