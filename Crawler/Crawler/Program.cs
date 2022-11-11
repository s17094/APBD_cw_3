using Crawler.Databases;
using Crawler.Exceptions;
using Crawler.Repositories;
using Crawler.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IStudentsService, StudentsService>();
builder.Services.AddSingleton<IStudentsRepository, StudentsRepository>();
builder.Services.AddSingleton<IDatabase, CsvDatabase>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<RestExceptionFilter>();
});
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();