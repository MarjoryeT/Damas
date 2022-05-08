using Jogar.Damas.Application.Users.Commands;
using Jogar.Damas.Data.Repositories;
using Jogar.Damas.Domain.Interface;
using Jogas.Damas.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//Injeções de dependecias
builder.Services.AddTransient<CreateUserCommand>();
builder.Services.AddTransient<LoginCommand>();
builder.Services.AddTransient<IUserRepository, UserRepository>();


await builder.Build().RunAsync();

