using Microsoft.EntityFrameworkCore;
using SimpleLearningDashboard.Data;
using SimpleLearningDashboard.Services;
using SimpleLearningDashboard.Components;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//qoutes
builder.Services.AddHttpClient<QuoteService>();

//register services
builder.Services.AddSingleton<CourseStorageService>();
//database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));
//services
builder.Services.AddScoped<UserSession>();
//theme service
builder.Services.AddScoped<ThemeService>();



var app = builder.Build();
//auto-create DB (no migrations yet)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}


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

app.Run();
