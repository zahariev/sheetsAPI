using System.Security.Cryptography.X509Certificates;


namespace sheetsApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using sheetsApi.Data;
    using sheetsApi.Models;
    using Microsoft.EntityFrameworkCore;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly DataContext _context;
        public ClientsController(DataContext context)
        {
            _context = context;

        }

        // [AllowAnonymous]
        // GET api/clients
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {

            var clients = await _context.Clients.ToListAsync();

            return Ok(clients);
        }

        // [AllowAnonymous]
        // GET api/clients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var project = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(project);
        }

        // POST api/clients
        [HttpPost]
        public IActionResult Post()
        {
            var client = new Client()
            {
                Name = "new client"
            };
            _context.Clients.Add(client);
            _context.SaveChanges();

            if (client.Id > 0) return Ok(client);
            // return 0;
            else return BadRequest("Insert failed");

        }


        // PUT api/clients
        [HttpPut()]
        public IActionResult Put([FromBody] Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();

            return Ok(client);
        }
        // DELETE api/clients/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var rec = new Client()
            {
                Id = id
            };

            _context.Clients.Remove(rec);
            _context.SaveChanges();

        }
    }
}
