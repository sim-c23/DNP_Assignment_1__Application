using Application.DaoInterfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWASM;
using BlazorWasm.Auth;
using BlazorWasm.Services;
using BlazorWasm.Services.Http;

using EfcDataAccess;
using EfcDataAccess.DAOs;
using FileData.DAOs;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7024") });
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<ITodoService, TodoHttpClient>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();

//DAO
builder.Services.AddScoped<IUserDao, UserEfcDao>();
builder.Services.AddScoped<ITodoDao, TodoEfcDao>();

//Add TodoContext as a Service
builder.Services.AddDbContext<TodoContext>();

AuthorizationPolicies.AddPolicies(builder.Services);



builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
