using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/states")]
    public class StatesController : Controller
    {
        private readonly StateContext _context;

        public StatesController(StateContext context)
        {
            _context = context;

            
        }

        [HttpGet]
        public IEnumerable<State> GetAll()
        {
            return _context.States.ToList();
        }
    }
}