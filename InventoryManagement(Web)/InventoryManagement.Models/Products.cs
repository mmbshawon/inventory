using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    
    public class Products
    {
        public int Id { get; set; }
        [Required]
        public string StyleName { get; set; }
        public int Dpp { get; set; }
        public int Dsp { get; set; }
        public int ProductQuantity { get; set; }
        public int CodeSeasonsId { get; set; }
        public virtual CodeSeasons CodeSeasons { get; set; }
        public int CodeProductGroupsId { get; set; }
        public virtual CodeProductGroups CodeProductGroups { get; set; }
        public int CodeProductTypesId { get; set; }
        public virtual CodeProductTypes CodeProductTypes { get; set; }
        public int CodeFabricsId { get; set; }
        public virtual CodeFabrics CodeFabrics { get; set; }
        public int CodeFitsId { get; set; }
        public virtual CodeFits CodeFits { get; set; }
        public int CodeCaresId { get; set; }
        public virtual CodeCares CodeCares { get; set; }
        public int CodeColorsId { get; set; }
        public virtual CodeColors CodeColors { get; set; }
        public int ProductSizesId { get; set; }
        public virtual ProductSizes ProductSizes { get; set; }



    }
}
