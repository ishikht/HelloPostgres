using HelloPostgres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloPostgres.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Message> Get()
        {
            var context = new DemoDbContext();
            return context.Messages.ToList();
        }

        public IEnumerable<Message> Add()
        {
            var context = new DemoDbContext();

            context.Messages.Add(new Message { Text = "hello Postgres from IIS" });
            context.SaveChanges();


            return context.Messages.ToList();
        }


    }
}
