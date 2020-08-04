namespace sheetsApi.Models
{

    using System;

    public class TimeSheet
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int ClientId { get; set; }
        public int UserId { get; set; }

        public string date { get; set; }

        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public string Description { get; set; }
    }
}