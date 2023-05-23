using BeerSender.Domain;
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
        options.JsonSerializerOptions.Converters.Add(new CommandConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EventContext>(opt => opt.UseSqlite("Data Source=events.db"));
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<Command_router>(provider =>
{
    var eventService = provider.GetRequiredService<IEventService>();
    return new Command_router(eventService.GetEvents, eventService.WriteEvent);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else
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
