using BookingManagement.Api.Models;
using System.Collections.ObjectModel;

namespace BookingManagement.Api.Services
{
    public class BookingManagementService : IBookingManagementService
    {
        private readonly AppDbContext db;
        public BookingManagementService(AppDbContext db)
        {
            this.db = db;
        }

        public BookingEvent GetOrder(int id)
        {
            BookingEvent order = db.BookingEvents.FirstOrDefault(o => o.Id == id);
            return order;
        }

        public List<BookingEvent> GetOrders()
        {
            var orders = db.BookingEvents.ToList();
            return orders;
        }

        public void CreateOrder(BookingEvent order)
        {
            db.BookingEvents.Add(order);
            db.SaveChanges();
        }

        public BookingEvent ChangeOrder(BookingEvent changedOrder)
        {
            BookingEvent order = db.BookingEvents.FirstOrDefault(o => o.Id == changedOrder.Id);
            if (order != null)
            {
                order.Name = changedOrder.Name;
                order.StartDate = changedOrder.StartDate;
                order.EndDate = changedOrder.EndDate;
                order.Price = changedOrder.Price;
                order.Deposit = changedOrder.Deposit;
                order.LockKey = changedOrder.LockKey;
                order.ArgbColor = changedOrder.ArgbColor;
            }
            db.SaveChanges();
            return order;
        }

        public void DeleteOrder(int id)
        {
            BookingEvent order = db.BookingEvents.FirstOrDefault(o => o.Id == id);
            db.BookingEvents.Remove(order);
            db.SaveChanges();
        }


    }
}
