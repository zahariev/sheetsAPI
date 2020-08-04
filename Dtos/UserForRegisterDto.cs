namespace sheetsApi.Dtos

{
    using System.ComponentModel.DataAnnotations;
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Your password must be 4 to 8 symbols length")]
        public string Password { get; set; }

    }
}