#nullable disable
using CRUDOperations.Common;
using CRUDOperations.DataContext;
using CRUDOperations.Services.CrudServices;
using ExcepitionMidLib.Builder.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICrudService, CrudService>();

//Configure database
builder.Services.AddDbContext<ProductDbContext>(option =>
option.UseMySQL(builder.Configuration.GetConnectionString(Constants.Db_Connection_String))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UserExceptionHandler(options =>
{
    options.DefaultInternalServerErrorCode = 500;
    options.DefaultDatabaseErrorCode = 400;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
