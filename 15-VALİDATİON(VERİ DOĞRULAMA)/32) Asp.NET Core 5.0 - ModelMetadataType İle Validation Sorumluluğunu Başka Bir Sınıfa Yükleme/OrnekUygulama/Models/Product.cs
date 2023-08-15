using Microsoft.AspNetCore.Mvc;
using OrnekUygulama.Models.ModelMetaDataTypes;

namespace OrnekUygulama.Models
{
    [ModelMetadataType(typeof(ProductMetadata))]
    public class Product
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Email { get; set; }
    }
}
