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
        [HttpGet]
        [Route("all")]
        public IEnumerable<Message> All()
        {
            var context = new DemoDbContext();
            return context.Messages.ToList();
        }

        [HttpGet]
        [Route("add")]
        public Message Add()
        {
            var context = new DemoDbContext();

            Message msg = new Message { Text = "hello Postgres from IIS" };
            context.Messages.Add(msg);
            context.SaveChanges();


            return msg;
        }


    }
}
