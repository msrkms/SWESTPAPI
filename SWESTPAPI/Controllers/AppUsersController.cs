using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SWESTPAPI.Data;
using SWESTPAPI.Logic;
using SWESTPAPI.Models;

namespace SWESTPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly SWESTPDBContext _context;

        public AppUsersController(SWESTPDBContext context)
        {
            _context = context;
        }

        // GET: api/AppUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetappUsers()
        {
            return await _context.appUsers.ToListAsync();
        }




        

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetAppUser(string id)
        {
            var appUser = await _context.appUsers.FindAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        [Route("~/api/Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Login login)
        {


            if (login.Email != null && login.Password != null)
            {
                AppUser appUser = _context.appUsers.Where(u => u.Email.Equals(login.Email)).FirstOrDefault();

                if (appUser!=null)
                {
                    if (MD5Hashing.VerifyMd5Hash(MD5.Create(), login.Password, appUser.Password))
                    {
                        return CreatedAtAction("GetAppUser", new { id = appUser.Email }, appUser);

                    }
                }
            }


            return NotFound();
             
            

        }


        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(string id, AppUser appUser)
        {
            if (id != appUser.Email)
            {
                return BadRequest();
            }

            _context.Entry(appUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(id))
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




        [Route("~/api/Registration")]
        [HttpPost]
        public async Task<ActionResult> PostAppUser(AppUser appUser)
        {
            MD5 mD5 = MD5.Create();

            appUser.Password = MD5Hashing.GetMd5Hash(mD5, appUser.Password);
            _context.appUsers.Add(appUser);
            await _context.SaveChangesAsync();

           Profile profile = new Profile();
           profile.Email = appUser.Email;
           _context.Profile.Add(profile);
         await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetAppUser", new { id = appUser.Email }, appUser);
        }

       

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppUser>> DeleteAppUser(string id)
        {
            var appUser = await _context.appUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            var profile =  _context.Profile.Where(p => p.Email.Equals(appUser.Email)).FirstOrDefault<Profile>();
            _context.Profile.Remove(profile);
            await _context.SaveChangesAsync();

            _context.appUsers.Remove(appUser);
            await _context.SaveChangesAsync();

            return appUser;
        }

        private bool AppUserExists(string id)
        {
            return _context.appUsers.Any(e => e.Email == id);
        }
    }
}
