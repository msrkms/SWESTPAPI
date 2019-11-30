using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SWESTPAPI.Data;
using SWESTPAPI.Models;

namespace SWESTPAPI.Controllers
{



    [Route("api/event")]
    public class EventController : Controller
    {

        private readonly SWESTPDBContext _context;

        public EventController(SWESTPDBContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Upload(IFormFile file,String JSON)
        {
            SweEvent sweEvent = new SweEvent();
            JObject jObject = JObject.Parse(JSON);
            SweEvent lastSweEvent = _context.sweEvents.LastOrDefault<SweEvent>();
            string attachmentName = null;


            if (file.Length > 0)
            {
                try
                {
                    if (file.FileName.Contains("seventfile"))
                    {
                        attachmentName = file.FileName;
                    }
                    else
                    {
                        attachmentName = "seventfile" + (lastSweEvent.ID+1) + file.FileName;
                    }


                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", attachmentName);
                    sweEvent.AttachmentUrl = (String)path;
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                sweEvent.AttachmentUrl = null;
            }


            sweEvent.Title = (String)jObject["title"];

            sweEvent.Date = (DateTime)jObject["date"];

            sweEvent.Time = (DateTime)jObject["time"];

            sweEvent.Details = (String)jObject["details"];



            _context.sweEvents.Add(sweEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSweEvent", new { id = sweEvent.ID }, sweEvent);
        }




        [HttpPost("update")]
        public async Task<IActionResult> Update(IFormFile file, String JSON)
        {
            
            SweEvent sweEvent = new SweEvent();
            JObject jObject = JObject.Parse(JSON);


            sweEvent.ID = (int)jObject["id"];
            sweEvent.Title = (String)jObject["title"];

            sweEvent.Date = (DateTime)jObject["date"];

            sweEvent.Time = (DateTime)jObject["time"];

            sweEvent.Details = (String)jObject["details"];

            

            string attachmentName = null;


            try
            {
                String oldfile = (String)jObject["attachmenturl"];
                System.IO.File.Delete(oldfile);
            }
            catch
            {

            }

            if (file.Length > 0)
            {
                try
                {
                    if (file.FileName.Contains("seventfile"))
                    {
                        attachmentName = file.FileName;
                    }
                    else
                    {
                        attachmentName = "seventfile" + (sweEvent.ID) + file.FileName;
                    }


                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", attachmentName);
                    sweEvent.AttachmentUrl = (String)path;
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                sweEvent.AttachmentUrl = null;
            }

            


            _context.Entry(sweEvent).State = EntityState.Modified;

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SweEventExists(sweEvent.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }






        

            return CreatedAtAction("GetSweEvent", new { id = sweEvent.ID }, sweEvent);
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


        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<SweEvent>>> GetsweEvents()
        {
            return await _context.sweEvents.ToListAsync();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<SweEvent>> DeleteSweEvent(int id)
        {
            var sweEvent = await _context.sweEvents.FindAsync(id);
            if (sweEvent == null)
            {
                return NotFound();
            }

            if (System.IO.File.Exists(sweEvent.AttachmentUrl))
            {
                System.IO.File.Delete(sweEvent.AttachmentUrl);
            }
            
            _context.sweEvents.Remove(sweEvent);
            await _context.SaveChangesAsync();



            return sweEvent;
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, SweEvent sweEvent)
        {
            if (id != sweEvent.ID)
            {
                return BadRequest();
            }

            _context.Entry(sweEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

        private bool SweEventExists(int id)
        {
            return _context.sweEvents.Any(e => e.ID == id);
        }

    }
}