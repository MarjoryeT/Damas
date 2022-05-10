using Jogar.Damas.Application.Users.Commands;
using Jogar.Damas.Blazor.Data;
using Jogar.Damas.Data.Context;
using Jogar.Damas.Data.Repositories;
using Jogar.Damas.Domain.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//Injeções de dependecias
builder.Services.AddTransient<CreateUserCommand>();
builder.Services.AddTransient<LoginCommand>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddDbContext<CheckersGameContext>(opt => opt.UseNpgsql("server=checkers.cgewd59i4zqt.us-east-1.rds.amazonaws.com;Port=5432;user id=checkers;password=YDAdARW3Pf442KwwpPB7;database=checkers"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
