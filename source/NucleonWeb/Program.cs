using System.Diagnostics;
using NucleonWeb.Components;

if (Chromium.Path == null)
{
    throw new InvalidOperationException("Looks like Chromium isn't included for your platform. Sorry!");
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

var chromiumProcess = Process.Start(Chromium.Path, "http://localhost:5281/");

app.Run();

// If you've reached here, the web server crashed. Terminate the browser.
if (!chromiumProcess.HasExited)
{
    chromiumProcess.Kill(true);
}