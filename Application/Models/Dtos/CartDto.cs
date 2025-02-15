using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class CartDto
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public bool Delivery { get; set; }
    }
}
