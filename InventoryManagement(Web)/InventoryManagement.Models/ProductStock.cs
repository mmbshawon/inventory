using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class ProductStock
    {
        public int Id { get; set; }
        public int SSize { get; set; }
        public int MSize { get; set; }
        public int LSizw { get; set; }
        public int XlSizw { get; set; }
        public int XxlSize { get; set; }
        public int ProductsId { get; set; }
        public virtual Products Products { get; set; }
    }
}
