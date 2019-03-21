using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Dtos.CategoryDtos
{
    public class CategoryDto
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Icon { get; set; }
    }
}
