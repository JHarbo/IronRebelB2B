using System.Collections.Generic;
using Newtonsoft.Json;

namespace IronRebelB2B.Models
{
    public class Products
    {
        [JsonProperty("products")]
        public List<Product> ProductList { get; set; }
    }
}