using CodingChallenge18June.Contexts;
using CodingChallenge18June.Interfaces;
using CodingChallenge18June.Models;
using CodingChallenge18June.Repositories;
using CodingChallenge18June.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", opts =>
    {
        opts.WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:3003", "http://localhost:3002", "http://localhost:3004", "http://localhost:3005", "http://localhost:3006", "http://localhost:3007", "http://localhost:3008").AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddDbContext<BookContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("juneConnection"));
});
builder.Services.AddScoped<IRepository<int, Books>, BookRepository>();

builder.Services.AddScoped<IBookService, BookService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
