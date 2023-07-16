using System.Collections.Generic;
using DAL;
using ML;

namespace BLL
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository = new ProductRepository();
        
        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}