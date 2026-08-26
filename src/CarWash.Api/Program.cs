using CarWash.Api.Filters;
using CarWash.Api.Middleware;
using CarWash.Application;
using CarWash.Infrastructure;
using CarWash.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter))); //Exceptions filters
builder.Services.AddInfrastructure(builder.Configuration); //dependency Injection of Infrastructure
builder.Services.AddApplication();  //dependency injection of Application 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await MigrateDatabase();

app.Run();

async Task MigrateDatabase() //start migration to database automatically
{
    await using var scope = app.Services.CreateAsyncScope();
    await DatabaseMigration.MigrateDatabase(scope.ServiceProvider);
    
}