using Abigo.Infrastructure;
using Abigo.Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DeployConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new ArgumentException("Connection string 'DefaultConnection' is null or empty.");
}

// Add services to the container.
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<AbigoDbAccess>(options => options.UseNpgsql(connectionString));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/Swagger/v1/swagger.json", "production document");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();