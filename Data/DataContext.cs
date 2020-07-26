namespace sheetsApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using sheetsApi.Models;
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sheets.db");
    }


}