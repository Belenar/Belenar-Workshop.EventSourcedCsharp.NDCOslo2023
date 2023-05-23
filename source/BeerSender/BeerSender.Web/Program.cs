using System.Text.Json;
using BeerSender.Domain.Box;
using BeerSender.Web.EventStore;
using BeerSender.Web.Hubs;
using BeerSender.Web.JsonHelpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new Command_converter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Event_context>(opt =>
    opt.UseSqlServer("Server=localhost,1433;Database=Vinmonopolet;User=sa;Password=RogerBeStrongYes1;TrustServerCertificate=True"));
builder.Services.AddScoped<Event_service, Event_service_implementation>();
builder.Services.AddScoped<Command_router>(r =>
{
    var event_server = r.GetRequiredService<Event_service>();
    return new Command_router(event_server.GetEvents, event_server.WriteEvent);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapHub<EventHub>("/event-hub");

app.Run();