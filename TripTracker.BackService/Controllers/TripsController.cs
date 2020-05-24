using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TripTracker.BackService.Data;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        private TripContext _context;

        public TripsController(TripContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }             

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var trips = await _context.Trips.AsNoTracking().ToListAsync();
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            //return _repository.Get(id);
            return _context.Trips.Find(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Trip value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Trips.Add(value);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task <IActionResult>PutAsync(int id, [FromBody]Trip value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!_context.Trips.Any(t => t.Id == id))
            {
                return NotFound();
            }

            _context.Trips.Update(value);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tripItem = _context.Trips.Find(id);
         
            if(tripItem == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(tripItem);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
