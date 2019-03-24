using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

      
        public string ImageUrl { get; set; }

        [MaxLength(500)]
        public string Desc { get; set; }
       
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Website { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Facebook { get; set; }

        [MaxLength(50)]
        public string Twitter { get; set; }

        [MaxLength(50)]
        public string Google { get; set; }

        [MaxLength(50)]
        public string Linkedin { get; set; }

        [MaxLength(50)]
        public string Youtube { get; set; }

        [Required, MaxLength(150)]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }



    }
}
