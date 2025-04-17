using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace MyMicroservice.Models
{
    public class LoginResponseDto
    {
        public string Token { get; set; }

        public string Message { get; set; }

    }
}
