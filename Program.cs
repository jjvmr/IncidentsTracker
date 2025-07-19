using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IncidentsTrackingSystem.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ProjHubContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjHubContext") ?? throw new InvalidOperationException("Connection string 'ProjHubContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

// Creates the database if it doesn't exist
    // TODO: Enable migrations  when the database schema is stable
    //      This will apply any pending migrations and create the database if it doesn't exist
    //      Migrations are used:
    //              to manage changes to the database schema over time.
    //              to preserve data across runs

    //using (var scope = app.Services.CreateScope())
    //{
    //    var dbContext = scope.ServiceProvider.GetRequiredService<ProjHubContext>();
    //    dbContext.Database.Migrate();
    //}

// When data doesnt need to be preserved across runs, you can use EnsureCreated
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var dbContext = services.GetRequiredService<ProjHubContext>();
    dbContext.Database.EnsureCreated();
    DbInitializer.Initialize(dbContext);
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
