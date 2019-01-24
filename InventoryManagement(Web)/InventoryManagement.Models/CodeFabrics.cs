using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class CodeFabrics
    {
        public int Id { get; set; }

        [Required]
        public string FabricsName { get; set; }

    }
}
