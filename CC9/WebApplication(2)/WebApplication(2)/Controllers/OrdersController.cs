using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication_2_.Controllers
{
    public class OrdersController : ApiController
    {
        private YourDbContext db = new YourDbContext(); 
         [HttpGet] 
        [Route("api/Orders/Buchanan")]
         public IHttpActionResult GetOrdersByEmployee() 
        { 
            var orders = db.Orders 
                .Where(o => o.EmployeeID == 5) 
                .Select(o => new 
                {
                    o.OrderID, 
                    o.CustomerID, 
                    o.OrderDate, 
                    o.ShipCity 
                }).ToList(); 
            return Ok(orders); 
        }
    }
}
