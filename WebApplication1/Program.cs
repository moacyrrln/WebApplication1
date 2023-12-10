//dotnet new Webapi -o BookStore
//dotnet dev-certs https --trust
//dotnet add package Microsoft.EntityFrameworkCore  --version 7.0.14
//dotnet add package Microsoft.EntityFrameworkCore.SqlServer  --version 7.0.14
//dotnet add package Microsoft.EntityFrameworkCore.Design  --version 7.0.14
//dotnet add package FluentAssertions.AspNetCore.Mvc --version 4.2.0
//dotnet tool install --global dotnet-ef
//dotnet ef migrations add MinhaPrimeiraMigration
//dotnet ef database update
//dotnet ef migrations add AdicionadoEmail
//dotnet ef database update

using BookStore.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<BookStoreContext>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookStoreContext, BookStoreContext>();
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
