using BookingManagement.Api.Models;
using System.Collections.ObjectModel;

namespace BookingManagement.Api.Services
{
    public interface IBookingManagementService
    {
        void CreateOrder(BookingEvent order);
        void DeleteOrder(int id);
        BookingEvent ChangeOrder(BookingEvent order);
        List<BookingEvent> GetOrders();
        BookingEvent GetOrder(int id);

    }
}
