using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
namespace WebAPIDemo.Models
{
    public interface IRepository
    {
        //System.Linq.IQueryable<Order> GetAllOrders();
        //System.Linq.IQueryable<Order> GetAllOrdersWithDetails();
        //Order GetOrder(int id);

        string MetaData { get; }

        SaveResult SaveChanges(JObject savebundle);

        IQueryable<Book> Books();

        IQueryable<Order> Orders();

    }
}
