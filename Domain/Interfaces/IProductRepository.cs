using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        public Product? GetProductById(int id);
        public List<Product> GetProducts();
        public int AddProduct(Product product);
        public void UpdateProduct(int id, Product product);
        public void DeleteProduct(int id);

    }
}
