using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models
{
    public class SidebarForm
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [Required]
        public string MessageText { get; set; }
    }
}
