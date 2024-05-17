using FriendsTracker.Components.Pages;
using FriendsTracker.Components;
using MongoDB.Driver;
using Microsoft.VisualBasic;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
// builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<RankRequestHandler>());
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//mongo connection string key
// mongoKey = builder.Configuration["Apps:MongoDBPassword"];
try
{
string[] lines = File.ReadAllLines("../../secrets.txt");
mongoKey = lines[0];
henrik_API_Key = lines[1];
}
catch
{
Console.WriteLine("secrets.txt not found, okay while testing");
}

mongoKey = builder.Configuration["Apps:MongoDBPassword"];


henrik_API_Key = builder.Configuration["Apps:HenrikAPI"];

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseWebSockets();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

public partial class Program ()
{
    public static string? mongoKey { get; private set; }
    public static string? henrik_API_Key { get; private set; }
}