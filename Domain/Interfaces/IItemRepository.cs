using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IItemRepository
    {
        public Item? GetItemById(int id);
        public List<Item> GetItems();
        public List<Item> GetItemsByProductId(int productId);
        public int AddItem(Item item);
        public void UpdateItem(int id, Item item);
        public void RemoveItems(List<Item> items);
        public void DeleteItem(int id);
        
    }
}
