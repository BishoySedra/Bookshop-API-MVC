using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Register custom error handling middleware
builder.Services.AddControllersWithViews().ConfigureApiBehaviorOptions(options =>
    {
        // Use custom validation error handler
        options.InvalidModelStateResponseFactory = context =>
        {
            return ValidationErrorHandler.CustomModelStateResponse(context);
        };
    });

// Add Swagger support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BookShop API",
        Version = "v1",
        Description = "API for managing book categories"
    });
});

var app = builder.Build();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// Register custom error handling middleware BEFORE other middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Enable Swagger middleware in dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookShop API v1");
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // Required to serve CSS/JS/etc
app.UseRouting();     // Required for routing to views/controllers

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CategoryView}/{action=Index}/{id?}"
);

app.Run();
