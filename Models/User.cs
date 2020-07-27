namespace sheetsApi.Models
{
    using System;
    public class User
    {
        public int Id { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


        /// <summary>
        /// The display name of the Team Member
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The job position of the Team Member
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// The date/time the team member object was created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Inactive users are not displayed in the UI
        /// </summary>
        public bool Active { get; set; }
    }
}