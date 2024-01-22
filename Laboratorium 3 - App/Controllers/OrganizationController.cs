using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizationController(AppDbContext context)
        {
            _context = context;
        }

        [Route("filter")]
        public IActionResult GetFilteredOrganizations(string q)
        {
            var result = _context.Hotels.Where(o => o.Name.StartsWith(q)).Select(o => new { Id = o.Id, Name = o.Name}).ToList();
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
