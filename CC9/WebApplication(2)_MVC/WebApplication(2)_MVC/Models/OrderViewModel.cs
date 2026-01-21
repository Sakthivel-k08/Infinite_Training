using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_2__MVC.Models
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipCity { get; set; }
    }
}