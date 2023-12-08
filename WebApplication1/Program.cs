//dotnet new Webapi -o BookStore
//dotnet dev-certs https --trust
//dotnet add package Microsoft.EntityFrameworkCore  --version 7.0.14
//dotnet add package Microsoft.EntityFrameworkCore.SqlServer  --version 7.0.14
//dotnet add package Microsoft.EntityFrameworkCore.Design  --version 7.0.14
//dotnet add package FluentAssertions.AspNetCore.Mvc --version 4.2.0

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
