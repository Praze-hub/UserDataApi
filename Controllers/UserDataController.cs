using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WellaApi.Models;
using WellaApi.DatabaseContext;

namespace WellaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDataController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserDataController(AppDbContext context){
            _context = context;
        }

        [HttpGet("[action]")]
        public IActionResult Index()
        {
            var user = _context.UserDataTable.ToList();
            return Ok(user);
        }

        [HttpGet("[action]")]
        public IActionResult NewUser()
        {
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> NewUser(UserData user){

            if(ModelState.IsValid)
            {
                
                await _context.UserDataTable.AddAsync(user);
                await _context.SaveChangesAsync();
                

            }
                return Ok( "name is"+user.FirstName+user.LastName+"Phone number is"+user.Phonenumber);
            
        }   
         [HttpGet("[action]")]
         public async Task<IActionResult> EditAsync(int ID){
            var user = await _context.UserDataTable.FirstOrDefaultAsync(x=>x.ID==ID);
            return Ok(user);

        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(UserData model){
            var user = await _context.UserDataTable.FirstOrDefaultAsync(x=>x.ID==model.ID);
            _context.UserDataTable.Update(user);
            await _context.SaveChangesAsync();
            return Ok("name changed to "+model.FirstName+model.LastName);
        }

        [HttpGet("[action]")]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteAsync(int ID){
            var user = await _context.UserDataTable.FirstOrDefaultAsync(x=>x.ID==ID);
            return Ok();
        }

       [HttpPost("[action]")]
        public async Task<IActionResult> DeleteAsync(UserData model){
            var user = await _context.UserDataTable.FirstOrDefaultAsync(x=>x.ID==model.ID);
            _context.UserDataTable.Remove(user);
            await _context.SaveChangesAsync();
            return Ok("User successfully deleted");
        }

    }
}
