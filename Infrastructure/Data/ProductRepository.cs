using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product? GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(u => u.Id == id);
        }
        public List<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public int AddProduct(Product product)
        {
            _dbContext.Products.Add(product);

            _dbContext.SaveChanges();

            return product.Id;
        }

        public void UpdateProduct(int id, Product product)
        {
            var existingProduct = _dbContext.Products.FirstOrDefault(u => u.Id == id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                existingProduct.Brand = product.Brand;
                _dbContext.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
