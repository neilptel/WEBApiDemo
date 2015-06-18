using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Breeze.WebApi2;
using WebAPIDemo.Models;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;
using System.Web.Http;


namespace WebAPIDemo.Controllers
{
    [BreezeController]
    public class BreezeController : ApiController
    {
        private readonly IRepository _repo;

        public BreezeController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public string MetaData()
        {
            return _repo.MetaData;
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject savebundle) 
        {
            return _repo.SaveChanges(savebundle);
        }

        [HttpGet]
        public IQueryable<Book> Books() 
        {
            return _repo.Books();
        }

        [HttpGet]
        public IQueryable<Order> Orders() 
        {
            return _repo.Orders();
        }


    }
}