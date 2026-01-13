using Application_1.Models;
using System.Linq;
using System.Web.Mvc;

namespace NorthwindMvc.Controllers
{
    public class CodeController : Controller
    {
        private readonly NorthWindEntities _db = new NorthWindEntities();

        public ActionResult GermanCustomers()
        {
            var customers = _db.Customers
                               .Where(c => c.Country == "Germany")
                               .OrderBy(c => c.CompanyName)
                               .ToList();

            return View(customers); 
        }

        public ActionResult OrderDetails(int id = 10248)
        {
            var order = _db.Orders.FirstOrDefault(o => o.OrderID == id);

            if (order == null)
            {
                return HttpNotFound($"Order with ID {id} not found.");
            }

            

            return View(order); 
        }

        //public void Dispose(bool disposing)
        //{
        //    if (disposing) _db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
