using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication_2__MVC.Models;

namespace WebApplication_2__MVC.Controllers
{
    public class OrderViewerController : Controller
    {
        // GET: OrderViewer
        public ActionResult Index()
        {
            List<OrderViewModel> orders = new List<OrderViewModel>(); using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:xxxx/"); 
                 var response = client.GetAsync("api/Orders/Buchanan").Result; 
                if (response.IsSuccessStatusCode) 
                {
                    var json = response.Content.ReadAsStringAsync().Result; 
                    orders = JsonConvert.DeserializeObject<List<OrderViewModel>>(json); 
                }
            }
            return View(orders);
        }
    }
}