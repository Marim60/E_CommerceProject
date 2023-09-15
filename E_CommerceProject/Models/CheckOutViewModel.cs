using System.ComponentModel.DataAnnotations;

namespace E_CommerceProject.Models
{
    public class CheckOutViewModel
    {
        [Required(ErrorMessage ="You Should Enter Your First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You Should Enter Your Last Name")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a valid email address for shipping updates.")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a valid username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your shipping address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Zip code required.")]

        public string Zip { get; set; }
        [Required(ErrorMessage = "Credit card number is required")]

        public string CridtCardNumber { get; set; }
        [Required(ErrorMessage = "Credit card Name is required")]

        public string CridtCardName { get; set; }
        [Required(ErrorMessage = "CVV is required")]

        public string CVV { get; set; }
        [Required(ErrorMessage = "Expiration Date is required")]

        public string Expiration { get; set; }
    }
}
