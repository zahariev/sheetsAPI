
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

    [Authorize]
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

        // [AllowAnonymous]
        // GET api/projects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(project);
        }

        // POST api/projects
        [HttpPost]
        public IActionResult Post()
        {
            var project = new Project()
            {
                Name = "new project"
            };
            _context.Projects.Add(project);
            _context.SaveChanges();

            if (project.Id > 0) return Ok(project);
            // return 0;
            else return BadRequest("Insert failed");

        }


        // PUT api/projects
        [HttpPut()]
        public IActionResult Put([FromBody] Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();

            return Ok(project);
        }
        // DELETE api/projects/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var rec = new Project()
            {
                Id = id
            };

            _context.Projects.Remove(rec);
            _context.SaveChanges();
        }
    }
}
