using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.Middlewares;
using WebApi.Services;
using WebApi.Repositories;
using WebApi.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TheathersDbContext>(options => options.UseInMemoryDatabase(databaseName:"TheathersDb"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILoggerService,ConsoleLogger>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()){
     var services = scope.ServiceProvider;
     DataGenerator.Initialize(services);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomExpectionMiddleware();

app.MapControllers();

app.Run();
