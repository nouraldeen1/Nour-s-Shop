using System.ComponentModel.DataAnnotations;

namespace Nour_Shop.ViewModels
{
    public class signUp
    {

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public int age { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } 
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public string Address { get; set; } = null!;

        public string Sex { get; set; } = null!;
        public string Mobile { get; set; }


    }
}
