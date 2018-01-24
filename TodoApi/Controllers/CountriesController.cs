using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/countries")]
    public class CountriesController : Controller
    {
        private readonly CountryContext _context;
        private readonly StateContext _stateContext;

        public CountriesController(CountryContext context, StateContext stateContext)
        {
            _context = context;
            _stateContext = stateContext;

            if (_context.Countries.Count() == 0)
            {
                Country country = new Country { Name = "United States", Code = "US" };
                State state = new State { Name = "Virginias", Code = "VA", Country = country, CountryId = country.CountryId };
                _stateContext.States.Add(state);
                _context.Countries.Add(country);
                _context.SaveChanges();
                _stateContext.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Country> GetAll()
        {
            return _context.Countries.ToList();
        }

        [HttpGet("{id}", Name = "GetCountry")]
        public IActionResult GetById(long id)
        {
            var item = _context.Countries.FirstOrDefault(t => t.CountryId == id);
            if (item == null)
            {
                return NotFound();
            }

            item.States = item.States;
            return new ObjectResult(item);
        }
    }
}