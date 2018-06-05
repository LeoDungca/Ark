using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ark.Mvc.Models
{
    public class CommentViewModel
    {
        [Required]
        [MaxLength(12, ErrorMessage = "Name should be 12 character in length")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Comment should be 250 character in length")]
        public string Comment { get; set; }
    }
}
