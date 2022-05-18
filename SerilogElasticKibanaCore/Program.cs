using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
{
    return new ElasticsearchSinkOptions(new Uri(configuration["Elasticsearch:ElasticUrl"]))
    {
        AutoRegisterTemplate = true,
        IndexFormat = String.Format(configuration["Elasticsearch:ElasticIndexFormat"], DateTime.UtcNow)
    };
}

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .WriteTo.Console()
                .WriteTo.Elasticsearch(ConfigureElasticSink(builder.Configuration, builder.Environment.EnvironmentName))
                .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
