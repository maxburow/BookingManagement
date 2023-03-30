using BookingManagement.Api.Models;
using BookingManagement.Api.Services;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IBookingManagementService, BookingManagementService>();
builder.Services.AddSingleton<AppDbContext>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/orders", (IBookingManagementService db) =>
{
    var bookingEvents = db.GetOrders();
    return bookingEvents;
})
.WithName("GetBookingEvents");

app.MapGet("/orders/{id}", (IBookingManagementService db, string id) =>
{
    var bookingEvent = db.GetOrder(int.Parse(id));
    return bookingEvent;
})
.WithName("GetBookingEvent");

app.MapPost("/orders", (IBookingManagementService db, BookingEvent order) =>
{
    db.CreateOrder(order);
    return order;
})
.WithName("CreateBookingEvent");

app.MapDelete("/orders/{id}", (IBookingManagementService db, string id) =>
{
    db.DeleteOrder(int.Parse(id));
    return StatusCodes.Status200OK;
})
.WithName("DeleteBookingEvent");

app.MapPut("/orders/", (IBookingManagementService db, BookingEvent order) =>
{
    return Results.Json(db.ChangeOrder(order));
})
.WithName("EditBookingEvent");

app.Run();
