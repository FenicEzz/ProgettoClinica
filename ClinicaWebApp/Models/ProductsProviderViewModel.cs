using DataLayer.Entities;

namespace ClinicaWebApp.Models
{
    public class ProductsProviderViewModel
    {
        public Provider Provider { get; set; }
        public List<Product> Products { get; set;} 
    }
}
