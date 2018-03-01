using IronRebelB2B.Models;
using System.Collections.Generic;

namespace IronRebelB2B.ViewModels
{
    public class ProductCardViewModel
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public IEnumerable<Variant> Variants { get; set; }

        public class Variant
        {
            public string Title { get; set; }
            public int? InventoryQuantity { get; set; }
        }
    }
}
