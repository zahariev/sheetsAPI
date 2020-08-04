using System.Linq;

namespace sheetsApi.Controllers
{
    using System.Security.Cryptography.X509Certificates;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using sheetsApi.Data;
    using sheetsApi.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetsController : ControllerBase
    {
        private readonly DataContext _context;
        public TimesheetsController(DataContext context)
        {
            _context = context;

        }


        // GET api/timesheets
        [HttpGet]
        // [FromBody] int userId
        public async Task<IActionResult> GetTimeSheets()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)); // will give the user's userId


            var timesheets = await _context.TimeSheets.Where(c => c.UserId == userId).ToListAsync();

            return Ok(timesheets);
        }

        // GET api/timsheets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimeSheet(int id)
        {
            var timesheet = await _context.TimeSheets.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(timesheet);
        }

        // POST api/timesheets
        [HttpPost]
        public IActionResult Post(TimeSheet timeSheet)
        {

            timeSheet.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));


            _context.TimeSheets.Add(timeSheet);
            _context.SaveChanges();


            return Ok();
        }




        // PUT api/projects/5
        [HttpPut()]
        public IActionResult Put(TimeSheet timeSheet)
        {
            timeSheet.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));


            _context.TimeSheets.Update(timeSheet);
            _context.SaveChanges();


            return Ok();
        }

        // DELETE api/projects/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var rec = new TimeSheet()
            {
                Id = id
            };

            _context.TimeSheets.Remove(rec);
            _context.SaveChanges();
        }
    }
}
