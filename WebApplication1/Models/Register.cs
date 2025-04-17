using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace MyMicroservice.Models
{
    public class Register
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public string DOBDate { get; set; }

        public string DOBTime { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Street1 is required")]
        public string Street1 { get; set; }

        public string Street2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Pincode is required")]
        public string Pincode { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public static implicit operator int(Register v)
        {
            throw new NotImplementedException();
        }
    }
}