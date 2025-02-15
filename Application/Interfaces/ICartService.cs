using Application.Models.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICartService
    {
        public Cart? GetCartById(int id);
        public Cart? GetCartByClientId(int id);
        public List<Cart> GetCarts();
        public int AddCart(CartDto cartDto);
        public void UpdateCart(int id, bool delivery);
        public void DeleteCart(int id);
    }
}
