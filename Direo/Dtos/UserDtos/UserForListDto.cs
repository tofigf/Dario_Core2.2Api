using Direo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Dtos
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageUrl { get; set; }
        public string Desc { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Linkedin { get; set; }
        public string Youtube { get; set; }
    }
}
