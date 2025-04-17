using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace MyMicroservice.Models
{
    public class LoginRequestDto
    {
        public required string UserName { get; set; }

        public required string Password { get; set; }

    }
}
