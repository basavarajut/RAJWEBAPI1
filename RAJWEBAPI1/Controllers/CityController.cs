using Microsoft.AspNetCore.Mvc;
using RAJWEBAPI1.Data;
using RAJWEBAPI1.Models.Domain;

namespace RAJWEBAPI1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CityController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetCityById")]
        public async Task<City> GetCity(int Id)
        {
            var _city = _context.Cities.Where(x => x.CityId == Id).FirstOrDefault();

            var city = new City()
            {
                CityId = _city.CityId,
                CityName = _city.CityName,
                StateId = _city.StateId
            };

            return city;
        }

        [HttpPost("PostCity")]
        public async Task<ActionResult<City>> CreateCity(City city)
        {
            var _city = new City()
            {
                CityId = city.CityId,
                CityName = city.CityName,
                StateId = city.StateId,
            };
            
             _context.Cities.Add(_city);
            await _context.SaveChangesAsync();

            return Ok(_city);
        }
    }
}
