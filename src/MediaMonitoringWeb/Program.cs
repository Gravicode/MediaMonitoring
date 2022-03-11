using MediaMonitoringWeb.Data;
using MediaMonitoringWeb.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Python.Runtime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<SastrawiHelper>();
builder.Services.AddSingleton<NltkHelper>();
var app = builder.Build();
var config = app.Configuration;

AppConstants.CONSUMER_SECRET =  config["Twitter:CONSUMER_SECRET"];
AppConstants.CONSUMER_KEY =  config["Twitter:CONSUMER_KEY"];
AppConstants.ACCESS_TOKEN =  config["Twitter:ACCESS_TOKEN"];
AppConstants.ACCESS_TOKEN_SECRET =  config["Twitter:ACCESS_TOKEN_SECRET"];
AppConstants.PYTHON_DLLPATH =  config["Python:PYTHON_DLLPATH"];
//init python dll
Runtime.PythonDLL = AppConstants.PYTHON_DLLPATH;
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
