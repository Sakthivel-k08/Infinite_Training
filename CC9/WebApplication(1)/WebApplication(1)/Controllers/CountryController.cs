using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication_1_.Models;

namespace WebApiAssessment_1_.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "USA", Capital = "Washington D.C." }
        };

        public IHttpActionResult Get()
        {
            return Ok(countries);
        }

        public IHttpActionResult Get(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            return Ok(country);
        }

        public IHttpActionResult Post([FromBody] Country country)
        {
            if (country == null)
                return BadRequest("Invalid data.");

            countries.Add(country);
            return Ok(country);
        }

        public IHttpActionResult Put(int id, [FromBody] Country updatedCountry)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;

            return Ok(country);
        }

        public IHttpActionResult Delete(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            countries.Remove(country);
            return Ok("Deleted successfully");
        }
    }
}
