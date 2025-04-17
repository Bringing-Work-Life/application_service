using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace MyMicroservice.Models
{
    public class RegisterDto
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string DOBDate { get; set; }

        public string DOBTime { get; set; }

        public string Phone { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Pincode { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

    }
}
