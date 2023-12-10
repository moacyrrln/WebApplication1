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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<BookStoreContext>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookStoreContext, BookStoreContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("chavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquerchavequalquer"))
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => policy.RequireClaim(ClaimTypes.Role, "admin")/*.RequireClaim(nova claim)*/);
});

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
