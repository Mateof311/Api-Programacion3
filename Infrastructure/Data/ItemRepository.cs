using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Item? GetItemById(int id)
        {
            return _dbContext.Items.FirstOrDefault(u => u.Id == id);
        }
        public List<Item> GetItems()
        {
            return _dbContext.Items.ToList();
        }
        public List<Item> GetItemsByProductId(int productId)
        {
            return _dbContext.Items.Where(i => i.ProductId == productId).ToList();
        }
        public int AddItem(Item item)
        {
            _dbContext.Items.Add(item);

            _dbContext.SaveChanges();

            return item.Id;
        }
        public void UpdateItem(int id, Item item)
        {
            var existingItem = _dbContext.Items.FirstOrDefault(u => u.Id == id);

            if (existingItem != null)
            {
                existingItem.Quantity = item.Quantity;

                _dbContext.SaveChanges();
            }
        }
        public void RemoveItems(List<Item> items)
        {
            _dbContext.Items.RemoveRange(items);
            _dbContext.SaveChanges();
        }
        public void DeleteItem(int id)
        {
            var item = _dbContext.Items.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                _dbContext.Items.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
