using System.Security.Cryptography.X509Certificates;


namespace sheetsApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using sheetsApi.Data;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly DataContext _context;
        public ProjectsController(DataContext context)
        {
            _context = context;

        }


        // GET api/projects
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {

            var projects = await _context.Projects.ToListAsync();

            return Ok(projects);
        }

        // GET api/projects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(project);
        }

        // POST api/projects
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/projects/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/projects/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
