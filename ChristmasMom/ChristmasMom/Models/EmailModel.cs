using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChristmasMom.Models
{
    public class EmailModel
    {
        [Required]
        public string Address { get; set;}
    }
}
