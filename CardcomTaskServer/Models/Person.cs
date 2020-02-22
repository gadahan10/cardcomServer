using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardcomTaskServer.Models
{
    public class Person
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name max length is up to 50 characters.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$", ErrorMessage = "Provided email address does not match the required email pattern.")]
        public string Email { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }
    }
}
