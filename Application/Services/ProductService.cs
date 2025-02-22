using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IItemRepository _itemRepository;

        public ProductService(IProductRepository productRepository, IItemRepository itemRepository)
        {
            _productRepository = productRepository;
            _itemRepository = itemRepository;
        }
        public Product? GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        public int AddProduct(ProductDto productDto)
        {
            var newProduct = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Brand = productDto.Brand,
            };
            return _productRepository.AddProduct(newProduct);
        }

        public void UpdateProduct(int id, ProductDto productDto)
        {
            var newProduct = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Brand = productDto.Brand,
            };
            _productRepository.UpdateProduct(id,newProduct);
        }
        public void DeletePoduct(int id)
        {
            var itemsToRemove = _itemRepository.GetItemsByProductId(id);
            if (itemsToRemove.Count != 0)
            {
                _itemRepository.RemoveItems(itemsToRemove);
            }
            _productRepository.DeleteProduct(id);
        }

    }
}
