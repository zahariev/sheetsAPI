using System.Security.Cryptography.X509Certificates;


namespace sheetsApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using sheetsApi.Data;

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly DataContext context;
        public ProjectsController(DataContext context)
        {
            this.context = context;

        }
        // GET api/projects
        [HttpGet]
        public IActionResult GetProjects()
        {

            var projects = this.context.Projects.ToList();

            return Ok(projects);
        }

        // GET api/projects/5
        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            var project = this.context.Projects.FirstOrDefault(x => x.Id == id);
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
