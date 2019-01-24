using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Sales
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime SaleDateTime { get; set; }
        public int ProductPrice { get; set; }
        [DataType (DataType.Text)]
        public string SaleProductName { get; set; }
        public int SaleQuantity { get; set; }    
        public int TotalPrice { get; set; }
      

    }
}
