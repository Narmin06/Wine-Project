using Microsoft.OpenApi.Models;
using App.Business;
using App.DAL;
using App.API;
using App.DAL.Presistence;
using App.Shared;

var builder = WebApplication.CreateBuilder(args);

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "App.API", Version = "v1" });
});

builder.Services
    .AddShared(builder.Configuration)
    .AddDataAccess(builder.Configuration)
    .AddBusiness(builder.Configuration);

builder.Services.AddSwagger();
builder.Services.AddJwt(builder.Configuration);

var app = builder.Build();

// ✅ DB migration - retry ilə (SQL gec açılırsa backend ölməsin)
using (var scope = app.Services.CreateScope())
{
    for (var i = 1; i <= 12; i++)
    {
        try
        {
            await AutomatedMigration.MigrateAsync(scope.ServiceProvider);
            Console.WriteLine("[MIGRATION] OK");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[MIGRATION] DB hazır deyil. Retry {i}/12. Error: {ex.Message}");
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}

// Pipeline
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowReactApp");
app.UseStaticFiles();
app.UseHttpsRedirection();

app.AddMiddlewares();
app.UseAuthorization();

app.MapControllers();
app.Run();