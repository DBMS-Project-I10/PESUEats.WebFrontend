using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PESUEatsBlazorServer.Services;
using MudBlazor.Services;
using PESUEatsBlazorServer;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.SessionStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<RestaurantsService>();

// HttpClient is registered as a scoped service. (so, 1 client per user - changes across page refresh)
builder.Services.AddHttpClient<PESUEatsWebAPIService>((client) =>
{
    client.BaseAddress = new Uri("http://127.0.0.1:5000/");
});
builder.Services.AddMudServices();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, PESUEatsAuthStateProvider>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
