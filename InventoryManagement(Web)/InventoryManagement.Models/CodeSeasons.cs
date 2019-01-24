using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class CodeSeasons
    {
        
        public int Id { get; set; }
        [Required]
        public string SeasonsName { get; set; }

    }
}
