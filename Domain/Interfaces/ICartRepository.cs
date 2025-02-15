using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICartRepository
    {
        public Cart? GetCartById(int id);
        public Cart? GetCartByClientId(int id);
        public List<Cart> GetCarts();
        public int AddCart(Cart cart);
        public void UpdateCart(int id, Cart cart);
        public void DeleteCart(int id);
    }
}
