using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public string Desc { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Linkedin { get; set; }
        public string Youtube { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserForRegisterDto()
        {
            CreatedAt = DateTime.Now;
        }

    }
}
