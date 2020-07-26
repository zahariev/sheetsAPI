namespace sheetsApi.Models
{
    using System.Collections.Generic;

    public class Client
    {
        public Client()
        {
            Projects = new List<Project>();
        }

        public int Id { get; set; }
        public int Name { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}