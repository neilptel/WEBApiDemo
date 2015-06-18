using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class Repository : WebAPIDemo.Models.IRepository
    {

        private WebAPIDemoContext db;

        private readonly EFContextProvider<WebAPIDemoContext> _contextProvider = new EFContextProvider<WebAPIDemoContext>();

        public SaveResult SaveChanges(Newtonsoft.Json.Linq.JObject savebundle)
        {
            //currently no guard logic but it can be done here.
            return _contextProvider.Context.SaveChanges(savebundle);
        }

        public IQueryable<Book> Books()
        {
            //This is place for validation/ user access etc.
            return _contextProvider.Context.Books;
        }

        public IQueryable<Order> Orders()
        {
            return _contextProvider.Context.Orders;
        }

        string IRepository.MetaData
        {
            get
            {
                return _contextProvider.Metadata();
            }
            
        }
    }
}