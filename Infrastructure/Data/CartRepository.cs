using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CartRepository(ApplicationDbContext dbContext)
        { 
            _dbContext = dbContext;
        }
        public Cart? GetCartById(int id)
        {
            return _dbContext.Carts.FirstOrDefault(u => u.Id == id);
        }
        public Cart? GetCartByClientId(int id)
        {
            return _dbContext.Carts.FirstOrDefault(u => u.ClientId == id);
        }
        public List<Cart> GetCarts()
        {
            return _dbContext.Carts.ToList();
        }
        public int AddCart(Cart cart)
        {
            _dbContext.Carts.Add(cart);

            _dbContext.SaveChanges();
            return cart.Id;

        }
        public void UpdateCart(int id, Cart cart)
        {
            var existingCart = _dbContext.Carts.FirstOrDefault(u => u.Id == id);

            if (existingCart != null)
            {
                existingCart.Delivery = cart.Delivery;

                _dbContext.SaveChanges();
            }
        }
        public void DeleteCart(int id)
        {
            var cart = _dbContext.Carts.FirstOrDefault(x => x.Id == id);

            if (cart != null)
            {
                _dbContext.Carts.Remove(cart);
                _dbContext.SaveChanges();
            }
        }
    }
}
