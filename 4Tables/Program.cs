using _4Tables.Config.Auth;
using _4Tables.Config.Extensions;
using _4Tables.Config.IoC;
using _4Tables.DataBase.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var jwtKey = builder.Configuration["Jwt:key"];

builder.InversionOfControlConfig();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql
    (
        builder.Configuration.GetConnectionString("DefaultConnection"))
    ); ;

builder.Services.AddJwtAuthentication(jwtKey);

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Migrate();
app.Run();
