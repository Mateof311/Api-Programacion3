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
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IClientRepository _clientRepository;
        public CartService(ICartRepository cartRepository, IClientRepository clientRepository)
        {
            _cartRepository = cartRepository;
            _clientRepository = clientRepository;
        }
        public Cart? GetCartById(int id)
        {
            return _cartRepository.GetCartById(id);
        }
        public Cart? GetCartByClientId(int id)
        {
            return _cartRepository.GetCartByClientId(id);
        }
        public List<Cart> GetCarts() 
        { 
            return _cartRepository.GetCarts();
        }
        public int AddCart(CartDto cartDto)
        {
            var newCart = new Cart()
            {
                ClientId = cartDto.ClientId,
                Delivery = cartDto.Delivery,
            };

            var response = _cartRepository.AddCart(newCart);
            _clientRepository.AddCartToClient(cartDto.ClientId, newCart);

            return response;

        }
        public void AddItemToCart(int cartId, int itemId)
        {
            _cartRepository.AddItemToCart(cartId, itemId);
        }
        public void UpdateCart(int id, bool delivery)
        {
            Cart cartInfo = _cartRepository.GetCartById(id);
            var newCart = new Cart()
            {
                ClientId = cartInfo.ClientId,
                Products = cartInfo.Products,
                Delivery = delivery,
            };

            _cartRepository.UpdateCart(id, newCart);
        }

        public void DeleteCart(int id)
        {
            var cart =_cartRepository.GetCartById(id);
            
            if (cart != null)
            { 
                var idClient = cart.ClientId;
                _clientRepository.DeleteClientCart(idClient);

                _cartRepository.DeleteCart(id);
            }
        }
    }
}
