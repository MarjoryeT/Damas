using Jogar.Damas.Application.Users.Commands;
using Jogar.Damas.Data.Context;
using Jogar.Damas.Data.Repositories;
using Jogar.Damas.Domain.Interface;
using Jogas.Damas.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//Injeções de dependecias
builder.Services.AddTransient<CreateUserCommand>();
builder.Services.AddTransient<LoginCommand>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<CheckersGameContext>();
//builder.Services.AddDbContext<CheckersGameContext>(opt => opt.UseNpgsql("server=checkers.cgewd59i4zqt.us-east-1.rds.amazonaws.com;Port=5432;user id=checkers;password=YDAdARW3Pf442KwwpPB7;database=checkers"));


await builder.Build().RunAsync();

