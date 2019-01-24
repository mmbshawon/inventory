using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class CodeColors
    {
        public int Id { get; set; }

        [Required]
        public string ColorsName { get; set; }

    }
}
