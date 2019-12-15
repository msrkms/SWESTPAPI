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
        public async Task<IActionResult> Login(Login login)
        {


            if (login.Email != null && login.Password != null)
            {
                AppUser appUser = await  _context.appUsers.Where(u => u.Email.Equals(login.Email)).FirstOrDefaultAsync();

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




        [Route("~/api/VerifyUser")]
        [HttpPost]
        public async Task<IActionResult> VerifyUser(Verify verify)
        {


            if (verify.Email != null && verify.VCode != null)
            {
                AppUser appUser = _context.appUsers.Where(u => u.Email.Equals(verify.Email)).FirstOrDefault();

                if (appUser != null)
                {
                    if (verify.VCode.Equals(appUser.VCode))
                    {
                        appUser.isVerified = "Verified";
                        _context.Entry(appUser).State = EntityState.Modified;
                        try
                        {
                            await _context.SaveChangesAsync();
                        }
                        catch
                        {
                            
                        }
                    }
                }

                return CreatedAtAction("GetAppUser", new { id = appUser.Email }, appUser);
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
                if (!AppUserExists(appUser.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAppUser", new { id = appUser.Email }, appUser);
        }




        [Route("~/api/Registration")]
        [HttpPost]
        public async Task<ActionResult> PostAppUser(AppUser appUser)
        {

            if (AppUserExists(appUser.Email))
            {
                return Ok(new { });
            }

            MD5 mD5 = MD5.Create();
            try
            {
                appUser.Password = MD5Hashing.GetMd5Hash(mD5, appUser.Password);
                _context.appUsers.Add(appUser);
                await _context.SaveChangesAsync();

                Profile profile = new Profile();
                profile.Email = appUser.Email;
                _context.Profile.Add(profile);
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                return Ok(new { });
            }

            return CreatedAtAction("GetAppUser", new { id = appUser.Email }, appUser);
        }


        [Route("~/api/SignUp")]
        [HttpPost]
        public async Task<ActionResult> SignUp(AppUser appUser)
        {

            if (AppUserExists(appUser.Email))
            {
                return Ok(new { });
            }

            MD5 mD5 = MD5.Create();
            try
            {
                appUser.Password = MD5Hashing.GetMd5Hash(mD5, appUser.Password);
               _context.appUsers.Add(appUser);               
               await _context.SaveChangesAsync();

                //  Profile profile = new Profile();
                //    profile.Email = appUser.Email;
                //    _context.Profile.Add(profile);
                //    await _context.SaveChangesAsync();

                String Q = @"insert into Profile (Email,Semester) values ('"+appUser.Email+"',0)";

                int x=  _context.Database.ExecuteSqlCommand(Q);


            }
            catch (Exception ex)
            {
                return Ok(new { });
            }

            return CreatedAtAction("GetAppUser", new { id = appUser.Email }, appUser);
        }







        private bool AppUserExists(string id)
        {
            return _context.appUsers.Any(e => e.Email == id);
        }
    }
}
