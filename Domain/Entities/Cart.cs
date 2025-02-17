using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public bool Delivery { get; set; }
        public List<Item>? Products { get; set; } = new List<Item>();
        public decimal TotalAmount => Products?.Sum(d => d.Total) ?? 0;

    }
}
