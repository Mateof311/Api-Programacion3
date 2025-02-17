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
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        public ItemService(IItemRepository itemRepository,IProductRepository productRepository, ICartRepository cartRepository )
        {
            _itemRepository = itemRepository;
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public Item? GetItemById(int id)
        {
           return _itemRepository.GetItemById(id);
        }
        public List<Item> GetItems()
        {
            return _itemRepository.GetItems();
        }
        public int AddItem(ItemDto itemDto)
        {
            Product productInfo = _productRepository.GetProductById(itemDto.ProductId);

            var newItem = new Item()
            {
                ProductId = itemDto.ProductId,
                ProductName = productInfo.Name,
                UnitPrice = productInfo.Price,
                Quantity = itemDto.Quantity,
            };
            return _itemRepository.AddItem(newItem);
        }
        public void UpdateItem(int id, int quantity)
        {
            Product productInfo = _productRepository.GetProductById(id);
            var newItem = new Item()
            {
                ProductId = productInfo.Id,
                ProductName = productInfo.Name,
                UnitPrice = productInfo.Price,
                Quantity = quantity,
            };

            _itemRepository.UpdateItem(id, newItem);
        }

        public void DeleteItem(int id)
        {
            _itemRepository.DeleteItem(id);
        }
    }
}
