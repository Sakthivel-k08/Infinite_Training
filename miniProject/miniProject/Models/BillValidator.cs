using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniProject.Models
{
    public class BillValidator
    {
        public string ValidateUnitsConsumed(int units)
        {
            return units < 0 ? "Given units is invalid" : "Valid";
        }
    }

}