using System.ComponentModel.DataAnnotations;

namespace Api.CenarioCapital.Infrastructure.Identity.Model
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}