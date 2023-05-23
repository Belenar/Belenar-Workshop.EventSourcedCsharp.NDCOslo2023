using BeerSender.Domain;
using BeerSender.Web.EventStore;
using BeerSender.Web.Hubs;
using BeerSender.Web.JsonHelpers;
using BeerSender.Web.Projections;
using BeerSender.Web.ReadStore;
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
    opt.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=Vinmonopolet;Integrated Security=True;"));
builder.Services.AddDbContext<Read_context>(opt =>
    opt.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=Taxfree;Integrated Security=True;"));

builder.Services.AddScoped<Event_service, Event_service_implementation>();
builder.Services.AddScoped<Command_router>(provider =>
{
    var event_service = provider.GetRequiredService<Event_service>();
    return new Command_router(event_service.GetEvents, event_service.WriteEvent);
});

builder.Services.AddScoped<Box_projection>();
builder.Services.AddHostedService<Projection_service<Box_projection>>();

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
