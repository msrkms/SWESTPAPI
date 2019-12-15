using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SWESTPAPI.Data;
using SWESTPAPI.Models;

namespace SWESTPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SweEventsController : ControllerBase
    {
        private readonly SWESTPDBContext _context;

        public SweEventsController(SWESTPDBContext context)
        {
            _context = context;
        }

        [Route("~/api/getAllEvents")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SweEvent>>> GetsweEvents()
        {
            return await _context.sweEvents.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SweEvent>> GetSweEvent(int id)
        {
            var sweEvent = await _context.sweEvents.FindAsync(id);

            if (sweEvent == null)
            {
                return NotFound();
            }

            return sweEvent;
        }

        // PUT: api/SweEvents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSweEvent(int id, SweEvent sweEvent)
        {
            if (id != sweEvent.ID)
            {
                return BadRequest();
            }

            _context.Entry(sweEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                
            return CreatedAtAction("GetSweEvent", new { id = sweEvent.ID }, sweEvent);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SweEventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SweEvents
        [HttpPost()]
        public async Task<ActionResult> PostSweEvent(SweEvent sweEvent)
        {
            
            _context.sweEvents.Add(sweEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSweEvent", new { id = sweEvent.ID }, sweEvent);
        }

        // DELETE: api/SweEvents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SweEvent>> DeleteSweEvent(int id)
        {
            var sweEvent = await _context.sweEvents.FindAsync(id);
            if (sweEvent == null)
            {
                return NotFound();
            }

            _context.sweEvents.Remove(sweEvent);
            await _context.SaveChangesAsync();

            return sweEvent;
        }






        private bool SweEventExists(int id)
        {
            return _context.sweEvents.Any(e => e.ID == id);
        }
    }
}
