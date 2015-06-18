using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class WebAPIDemoContextInitializer : DropCreateDatabaseAlways<WebAPIDemoContext>
    {
        protected override void Seed(WebAPIDemoContext context)
        {
            var books = new List<Book>
            {
                new Book() {Name = "War and Peace", Author="Sine Author", Price = 19 },
                new Book() {Name = "War and Peace 1", Author="Sine Author", Price= 20},
                new Book() {Name = "War and Peace 2", Author="Sine Author", Price= 22},
                new Book() {Name = "War and Peace 3", Author="Sine Author", Price= 25},
                new Book() {Name = "War and Peace 4 ", Author="Sine Author", Price= 26},
                new Book() {Name = "War and Peace 5 ", Author="Sine Author", Price= 30}
            };
            books.ForEach(b => context.Books.Add(b)); //Adding book in database
            context.SaveChanges();


            var order = new Order()
            {
                Customer = "John Doe",
                OrderDate = new DateTime(2001, 01, 02)
            };


            var details = new List<OrderDetail>{
                new OrderDetail() {Book = books[0], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[1], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[2], Quantity = 1, Order = order},
            };
            context.Orders.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();



            order = new Order()
            {
                Customer = "John Smith",
                OrderDate = new DateTime(1956, 01, 06)
            };


            details = new List<OrderDetail>{
                new OrderDetail() {Book = books[1], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[1], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[3], Quantity = 12, Order = order},
                new OrderDetail() {Book = books[4], Quantity = 12, Order = order},
            };
            context.Orders.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

            

            base.Seed(context);
        }
    }
}