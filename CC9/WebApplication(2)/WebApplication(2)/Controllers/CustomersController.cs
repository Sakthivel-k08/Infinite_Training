using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication_2_.Controllers
{
    public class CustomersController : ApiController
    {
        private YourDbContext db = new YourDbContext(); 
        [HttpGet] 
        [Route("api/Customers/ByCountry")] 
        public IHttpActionResult GetCustomersByCountry(string country) 
        {
            var result = db.GetCustomersByCountry(country).ToList(); 
           return Ok(result); 
        }
    }
}
