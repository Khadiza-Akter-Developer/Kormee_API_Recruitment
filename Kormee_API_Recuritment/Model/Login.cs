using System.ComponentModel.DataAnnotations;

namespace Kormee_API_Recuritment.Model
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }

    }
}
