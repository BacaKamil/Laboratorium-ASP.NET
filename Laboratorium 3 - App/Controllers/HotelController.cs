using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HotelController(AppDbContext context)
        {
            _context = context;
        }
        [Route("filter")]
        public IActionResult GetFilteredHotel(string q)
        {
            var result = _context.Hotels.Where(h => h.Name.StartsWith(q)).Select(h => new { Id = h.Id, Name = h.Name}).ToList();
            return Ok(result);
        }
        [Route("{id}")]
        public IActionResult GetHotelsById(int id) 
        {
            var entity = _context.Hotels.Find(id);
            if(entity == null) 
            { 
                return NotFound();
            }
            else
            {
                return Ok(entity);
            }
        }
    }
}
